using processDBDocumentation.Models;
using processDBDocumentation.Process;
using System;
using System.Collections.Generic;

namespace processDBDocumentation
{
    public class Program
    {
        private static string _assemblyParam = "Assembly";
        private static string _connectionStringParam = "ConnectionString";

        static void Main(string[] args)
        {
            Console.WriteLine("Este programa obtiene los comentarios de clases Entity de Entity Framework existentes en un ensamblado y los aplica como comentarios a la base de datos que se indique.");
            Console.WriteLine("\n*** PREREQUISITOS: ***");
            Console.WriteLine("1. El ensamblado que se especifique cómo origen debe contener clases Entity de Entity Framework.");
            Console.WriteLine("2. Cada clase debe implementar el TagAttribute TableAttribute para especificar el nombre de la tabla.");
            Console.WriteLine("3. Todas las tablas del sistema tienen el esquema [dbo].");
            Console.WriteLine("4. El nombre de las tablas debe ser exactamente igual al especificado en los TableAttribute de cada clase.");
            Console.WriteLine("5. Las clases deben contener propiedades que deben llamarse exactamente igual a los campos de las tablas a ser procesdadas.");
            Console.WriteLine("6. Los comentarios escritos en el tag <summary> de cada propiedad, serán los que se tomen para llevar a los campos de la base de datos.");

            bool containConnectionStringParam = false;
            bool containAssemblyParam = false;

            if (args.Length > 0)
            {
                string []connectionStringParam = Array.FindAll(args, s => s.Contains(_connectionStringParam));

                containConnectionStringParam = (connectionStringParam.Length > 0);

                string[] assemblyParam = Array.FindAll(args, s => s.Contains(_assemblyParam));

                containAssemblyParam = (assemblyParam.Length > 0);
            }

            if (args.Length > 2 || (args.Length > 0 && (!containConnectionStringParam || !containAssemblyParam)))
            {
                Console.WriteLine(string.Format("\nERROR: Número errado de parámetros. Use: processDBDocumentation {0}=[Connection String] {1}=[Assembly Path File]",
                    _connectionStringParam, _assemblyParam));

                return;
            }

            string connectionString = GetParamFromArgs(args, _connectionStringParam);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.Write("\nPor favor ingrese la cadena de conexión: ");

                connectionString = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    Console.WriteLine("No se especificó ningún valor.");

                    return;
                }
            }
            else
            {
                Console.WriteLine(string.Format("\n- Cadena de Conexión: \"{0}\"", connectionString));
            }

            string assembly = GetParamFromArgs(args, _assemblyParam);

            if (string.IsNullOrWhiteSpace(assembly))
            {
                Console.Write("\nPor favor ingrese la ruta del ensamblado: ");

                assembly = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(assembly))
                {
                    Console.WriteLine("No se especificó ningún valor.");

                    return;
                }
            }
            else
            {
                Console.WriteLine(string.Format("\n- Ensamblado: \"{0}\"", assembly));
            }

            AssemblyProcess assemblyProcess = new AssemblyProcess();

            List<Table> tableList = null;

            try
            {
                tableList = assemblyProcess.ProcessAssembly(assembly);
            }
            catch
            {
                return;
            }

            DatabaseProcess databaseProcess = new DatabaseProcess();

            try
            {
                databaseProcess.ProcessDatabase(connectionString, tableList);
            }
            catch
            {
                return;
            }

            Console.WriteLine("\nProceso terminado con éxito.");

            Console.ReadKey();
        }

        private static string GetParamFromArgs(string[] args, string paramName)
        {
            string paramValue = null;

            string[] parameters = Array.FindAll(args, s => s.Contains(paramName));

            if (parameters.Length > 1)
            {
                Console.WriteLine(string.Format("\nERROR: Se ha especificado el parámetro {0} más de una vez", paramName));
            }
            else
            {
                if (parameters.Length == 1)
                {
                    paramValue = parameters[0].Replace(paramName, string.Empty).Trim();

                    if (string.IsNullOrWhiteSpace(paramValue))
                    {
                        paramValue = null;
                    }
                    else
                    {
                        string nextChar = paramValue.Substring(0, 1);

                        if (nextChar == "=" || nextChar == ":")
                        {
                            paramValue = paramValue.Substring(1, paramValue.Length - 1);
                        }
                    }
                }
            }

            return paramValue;
        }
    }
}