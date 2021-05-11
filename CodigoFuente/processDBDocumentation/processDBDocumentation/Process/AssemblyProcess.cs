using processDBDocumentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace processDBDocumentation.Process
{
    public class AssemblyProcess
    {
        public List<Table> ProcessAssembly(string assemblyPath)
        {
            Console.WriteLine("\n*** Procesando Ensamblado ***\n    Obteniendo Tablas y Columnas a documentar...\n");

            List<Table> tableList = null;

            try
            {
                Assembly assemblyToProcess = Assembly.LoadFrom(assemblyPath);

                IEnumerable<Type> assemblyTypes = GetLoadableTypes(assemblyToProcess);

                tableList = new List<Table>();

                string tableName = null;
                string description = null;

                List<Column> columnList = null;

                foreach (Type t in assemblyTypes)
                {
                    tableName = this.GetTableName(t);

                    if (!string.IsNullOrWhiteSpace(tableName))
                    {
                        Console.WriteLine(string.Format("+ {0}", tableName));

                        description = this.GetTableDescription(t);

                        columnList = this.ProcessProperties(t, tableName);

                        tableList.Add(new Table()
                        {
                            Name = tableName,
                            Description = description,
                            Columns = columnList
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR: Error procesando el ensamblado.");

                Console.WriteLine(ex.Message);

                throw ex;
            }

            return tableList;
        }

        public List<Column> ProcessProperties(Type table, string tableName)
        {
            List<Column> columnList = null;

            try
            {
                PropertyInfo[] properties = table.GetProperties();

                columnList = new List<Column>();

                string columnName = null;
                string description = null;

                foreach (PropertyInfo p in properties)
                {
                    columnName = p.Name;
                    description = this.GetColumnDescription(p);

                    if (!string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine(string.Format(" - {0}", p.Name));

                        columnList.Add(new Column()
                        {
                            Name = columnName,
                            Description = description
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("\nERROR: Error procesando los campos de la tabla: {0}.", tableName));

                Console.WriteLine(ex.Message);

                throw ex;
            }

            return columnList;
        }

        public IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public string GetColumnDescription(PropertyInfo p)
        {
            DescriptionAttribute columnDescription = (DescriptionAttribute)Attribute.GetCustomAttribute(p, typeof(DescriptionAttribute));

            if (columnDescription == null)
            {
                return null;
            }
            else
            {
                return columnDescription.Description;
            }
        }

        public string GetTableDescription(Type t)
        {
            DescriptionAttribute tableDescription = (DescriptionAttribute)Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute));

            if (tableDescription == null)
            {
                return null;
            }
            else
            {
                return tableDescription.Description;
            }
        }

        public string GetTableName(Type t)
        {
            TableAttribute tableName = (TableAttribute)Attribute.GetCustomAttribute(t, typeof(TableAttribute));

            if (tableName == null)
            {
                return null;
            }
            else
            {
                return tableName.Name;
            }
        }
    }
}