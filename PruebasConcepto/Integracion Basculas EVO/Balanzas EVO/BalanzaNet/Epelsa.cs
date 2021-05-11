using EpelDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BalanzaNet
{
    #region Enumeradores de Eventos
    enum NombreEventosEnum
    {
        AgregarVendedor,
        ConfigurarBalanza,
        ActualizarVendedor,
        AgregarArticulo,
        EliminarVendedor,
        ExportarTiquete,
        ReiniciarNumeracionTiquete,
        EliminarArticulo,
        AgregarTeclaDirecta,
        EliminarTeclaDirecta,
        ActualizarArticulo,
        ActualizarTeclaDirecta,
        ConsultarArticulos,
        ConsultarVendedor,
    }
    #endregion

    #region Enumerador Tipo Peso
    public enum TipoPesoEnum
    {
        Peso = 1,
        Unidad = 0
    }
    #endregion

    /// <summary>
    /// Clase Epelsa
    /// </summary>
    ///
    public class Epelsa
    {
        #region Variables Globales
        public delegate void MostrarMensajeDelegate(string mensaje);
        public event MostrarMensajeDelegate MostrarMensajeEvento;
        public delegate void EnviarVendedorDelegate(VendedorEpelsa vendedor);
        public event EnviarVendedorDelegate EnviarVendedor;

        private TeclaDirecta _agregarTeclaDirecta;
        private TeclaDirecta _eliminarTeclaDirecta;
        private TeclaDirecta _actualizarTeclaDirecta;
        private NombreEventosEnum eventoEjecutado;
        private readonly Epel epelsa = null;
        private int IdMaquina = 0;
        private int TipoConfiguracion = 0;
        private string IpPuerto = string.Empty;
        private VendedorEpelsa VendedorEpelsa = null;
        private readonly List<Articulo> Articulos;
        private readonly TeclaDirecta TeclaDirecta = null;
        #endregion

        public Epelsa()
        {
            epelsa = new Epel();

            try
            {
                VendedorEpelsa = new VendedorEpelsa();
            }
            catch (Exception e)
            {
                throw e;
            }

            AgregarEventos();
        }

        #region Configurar Balanza
        public void Configurar(int idMaquina, int tipoConfiguracion, string direccionIp)
        {            
            this.IdMaquina = idMaquina;
            this.TipoConfiguracion = tipoConfiguracion;
            this.IpPuerto = direccionIp;

            ConfigurarBalanza();

            //string d = epelsa.Query_Item_GA(2023,1);
        }
        #endregion

        private void ConfigurarBalanza()
        {
            eventoEjecutado = NombreEventosEnum.ConfigurarBalanza;

            epelsa.Configure(IdMaquina, TipoConfiguracion, IpPuerto);
        }

        #region Cerrar Puertos/Estado Inicial
        /// <summary>
        /// Cierra los puertos de comunicaciones si estaban abiertos, y deja en el estado inicial al OCX (sin configurar)
        /// </summary>
        public void Reset()
        {
            epelsa.Reset();
        }
        #endregion

        #region Comunicación Balanza OK
        public void ComOK()
        {
            EventoEjecutado(null);
        }
        #endregion

        #region Comunicación Balanza Error
        public void ComError(int Error_Code)
        {
            EventoEjecutado(Error_Code);
        }
        #endregion

        #region Agregar Vendedor
        public void AgregarVendedor(int identificador, string nombre, int seccion, int tecla)
        {
            eventoEjecutado = NombreEventosEnum.AgregarVendedor;
            //AsignarVendedorEpelsa(identificador, nombre, seccion, tecla);
            epelsa.Send_Vendor(identificador, nombre, seccion, tecla, 1, 0);
        }
        #endregion

        #region Actualizar Vendedor
        public void ActualizarVendedor(int identificador, string nombre, int seccion, int tecla)
        {
            eventoEjecutado = NombreEventosEnum.ActualizarVendedor;
            //Buscar donde esté persistido el vendedor con el tecla asignada , si está lo actualizo de lo contrario notifique(Mensaje).
            if (VendedorEpelsa == null)
            {
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , Vendedor con tecla {tecla} No existe");
                return;
            }

            //AsignarVendedorEpelsa(identificador, nombre, seccion, tecla);
            epelsa.Send_Vendor(identificador, nombre, seccion, tecla, 1, 0);
        }
        #endregion

        #region Eliminar Vendedor
        public void EliminarVendedor(int identificador, string nombre, int seccion, int tecla)
        {
            eventoEjecutado = NombreEventosEnum.EliminarVendedor;
            epelsa.Send_Vendor(identificador, nombre, seccion, tecla, 0, 1);
        }
        #endregion

        //Epelsa no retorna todos los vendedores, entonces al ejecutar un AgregarVendedor y el evento OK se ejecuta; debemos agregar VendedorEpelsa a EVO
        //#region Vendedor Epelsa
        //private void AsignarVendedorEpelsa(int identificador, string nombre, int seccion, int tecla)
        //{
        //    VendedorEpelsa = new VendedorEpelsa()
        //    {
        //        Identificador = identificador,
        //        Nombre = nombre,
        //        Seccion = seccion,
        //        TeclaDirecta = tecla,
        //        //Estado = estado,
        //        EliminarVendedor = 0,
        //    };
        //}
        //#endregion        

        #region Agregar Artículo/Producto + Tecla Directa
        public void AgregarArticulo(int codigoPlu, string nombre, TipoPesoEnum tipoPeso, int programarSeccion, int numeroSeccion, int tablaTeclaDirecta, int numeroTeclaDirecta)
        {
            _agregarTeclaDirecta = new TeclaDirecta
            {
                ProgramarSeccion = programarSeccion,
                NumeroSeccion = numeroSeccion,
                TablaTeclaDirecta = tablaTeclaDirecta,
                Plu = 0,
                PluCodigo = codigoPlu,
                NumeroTeclaDirecta = numeroTeclaDirecta,
            };
            eventoEjecutado = NombreEventosEnum.AgregarArticulo;
            Epel_Item _agregarArticuloBalanza = new Epel_Item
            {
                //Código del Artículo; 1-999999; Id de tabla
                Code = codigoPlu,
                //Código del Artículo; 1-999999; 1485
                Plu = codigoPlu,
                //Sección a la que pertenece la balanza; entre 0 y 99
                Sec = 0,
                //25 carácteres -> Texto que aparece en el display
                Text = nombre,
                //1=Peso unitario. 0=Peso total en kgs.
                weight = tipoPeso == TipoPesoEnum.Peso ? 1 : 0,
                //Enviar siempre 100. Máximo 3 enteros.
                caducity = 100,
                //Siempre va en 0
                etq = 0,
                //# de Familia a la que pertenece el artículo. Máximo 3 enteros.
                Family = 12,
                //Siempre va en 0
                SubSec = 0,
                //Siempre va en 0
                Font = 0,
                //Siempre va en 0
                pref = 0,
                //Precio, valor entero.
                Price = 6666,
                //Siempre enviar 0
                tare = 0
            };

            if (codigoPlu.Equals(codigoPlu) || numeroTeclaDirecta.Equals(numeroTeclaDirecta))
            {
                ValidarSiExistePlu(codigoPlu, numeroTeclaDirecta);
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , La Tecla con Número: {numeroTeclaDirecta} ya existe");
                return;
            }

            if (numeroTeclaDirecta == Convert.ToInt32(string.Empty))
            {
                epelsa.Send_Item(_agregarArticuloBalanza);
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , La Tecla con Número: {numeroTeclaDirecta} Ha sido asignada");
                return;
            }
            else
            {
                ValidarSiExistePlu(codigoPlu, numeroTeclaDirecta);
                epelsa.Send_Item(_agregarArticuloBalanza);
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , La Tecla con Número: {numeroTeclaDirecta} fue agregada");
                return;
            }
        }
        #endregion

        #region Actualizar Artículo/Producto + Tecla Directa
        public void ActualizarArticulo(int codigoPlu, string nombre, TipoPesoEnum tipoPeso, int programarSeccion, int numeroSeccion, int tablaTeclaDirecta, int numeroTeclaDirecta)
        {
            //Aqui se valida si existe dato
            _actualizarTeclaDirecta = new TeclaDirecta
            {
                ProgramarSeccion = programarSeccion,
                NumeroSeccion = numeroSeccion,
                TablaTeclaDirecta = tablaTeclaDirecta,
                Plu = 0,
                PluCodigo = codigoPlu,
                NumeroTeclaDirecta = numeroTeclaDirecta,
            };
            eventoEjecutado = NombreEventosEnum.ActualizarArticulo;
            Epel_Item _actualizarArticuloBalanza = new Epel_Item
            {
                Code = codigoPlu,
                Plu = codigoPlu,
                Sec = 0,
                Text = nombre,
                weight = tipoPeso == TipoPesoEnum.Peso ? 1 : 0,
                caducity = 100,
                etq = 0,
                Family = 12,
                SubSec = 0,
                Font = 0,
                pref = 0,
                Price = 6666,
                tare = 0

            };

            if (codigoPlu.Equals(codigoPlu) == numeroTeclaDirecta.Equals(numeroTeclaDirecta))
            {
                ValidarSiExistePlu(codigoPlu, numeroTeclaDirecta);
                epelsa.Send_Item(_actualizarArticuloBalanza);
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , La Tecla con Número: {numeroTeclaDirecta} Ha sido Modificado");
                return;
            }

            //eventoEjecutado = NombreEventosEnum.ActualizarArticulo;
            //epelsa.Send_Item(_actualizarArticuloBalanza);
            //eventoEjecutado = NombreEventosEnum.EliminarArticulo;
            //epelsa.Erase_Item(1, codigoPlu);
            //epelsa.Send_Item(_actualizarArticuloBalanza);
        }
        #endregion

        #region Eliminar Artículo/Producto + Tecla Directa
        public void EliminarArticulo(int codigoPlu, int programarSeccion, int numeroSeccion, int tablaTeclaDirecta, int numeroTeclaDirecta)
        {
            _eliminarTeclaDirecta = new TeclaDirecta
            {
                ProgramarSeccion = programarSeccion,
                NumeroSeccion = numeroSeccion,
                TablaTeclaDirecta = tablaTeclaDirecta,
                Plu = 0,
                PluCodigo = codigoPlu,
                NumeroTeclaDirecta = numeroTeclaDirecta,
            };

            if (codigoPlu.Equals(codigoPlu) == numeroTeclaDirecta.Equals(numeroTeclaDirecta))
            {
                ValidarSiExistePlu(codigoPlu, numeroTeclaDirecta);
                MostrarMensajeEvento($"{eventoEjecutado.ToString()} , La Tecla con Número: {numeroTeclaDirecta} Ya ha sido eliminada, y se encuentra disponible");
                return;
            }

            eventoEjecutado = NombreEventosEnum.EliminarArticulo;

            epelsa.Erase_Item(1, codigoPlu);

        }
        #endregion

        #region Consultar Artículo Por Código
        public void ConsultarArticulo(int codigoPlu)
        {
            eventoEjecutado = NombreEventosEnum.ConsultarArticulos;
            string consultar = epelsa.Query_Item_GA(codigoPlu, 1);
            //consultar = "0013301330010000001Barriga con costilla     0011600000000000000W255";
            string nombreArticulo = string.Empty;
            foreach (char c in consultar)
            {
                if (char.IsLetter(c))
                {
                    nombreArticulo = consultar.Substring(consultar.IndexOf(c), 25).Trim();
                    break;
                }
            }

            MostrarMensajeEvento($"{eventoEjecutado.ToString()} Codigo Plu: {consultar}");

            string[] arrayLeerArticulo = consultar.Replace("\r\n", "?").Split('?');

            List<string> _consultarArticulo = new List<string>();

            foreach (string leerConsulta in arrayLeerArticulo)
            {
                List<TeclaDirecta> _consultarCodigo = new List<TeclaDirecta>();
                List<Articulo> _consultarNombreArticulo = new List<Articulo>();
                TeclaDirecta _leerTecla = null;

                _consultarArticulo.Add(leerConsulta.Substring(0, 6));

                _leerTecla = new TeclaDirecta();

                string codigo = leerConsulta.Substring(0, 6);

                if (leerConsulta == codigo)
                {
                    int _codigo = int.Parse(consultar.Substring(consultar.Length - 0, 6));
                    string _texto = consultar.Substring(consultar.Length);

                    _leerTecla.PluCodigo = codigoPlu;
                    break;
                }

                _consultarNombreArticulo = new List<Articulo>();

                foreach (var articulo in arrayLeerArticulo)
                {

                    Articulo articulosConsultados = null;
                    string _codigoAsignado = articulo.Substring(0, 6);

                    if (leerConsulta == codigo)
                    {
                        string plu = articulo.Substring(articulo.LastIndexOf(" "), 7);

                        Articulo _articuloDescripcion = new Articulo
                        {
                            Codigo = Convert.ToInt32(codigo),

                        };

                        articulosConsultados.Articulos.Add(_articuloDescripcion);
                    }
                }
            }

            Console.WriteLine($"Código = {codigoPlu} Nombre artículo = {nombreArticulo}");
            return;
        }
        #endregion

        #region Asignar Nueva Tecla Directa
        public void AsignarNuevaTeclaDirecta()
        {
            eventoEjecutado = NombreEventosEnum.AgregarTeclaDirecta;
            epelsa.Send_Key(_agregarTeclaDirecta.ProgramarSeccion, _agregarTeclaDirecta.NumeroSeccion, _agregarTeclaDirecta.TablaTeclaDirecta, 0, _agregarTeclaDirecta.PluCodigo, _agregarTeclaDirecta.NumeroTeclaDirecta);
            //epelsa.Send_Key(1,1,0,0,2024,41);
        }
        #endregion

        #region Asignar Actualizar Tecla Directa
        public void AsignarActualizarTeclaDirecta()
        {
            eventoEjecutado = NombreEventosEnum.ActualizarTeclaDirecta;
            epelsa.Send_Key(_actualizarTeclaDirecta.ProgramarSeccion, _actualizarTeclaDirecta.NumeroSeccion, _actualizarTeclaDirecta.TablaTeclaDirecta, 0, _actualizarTeclaDirecta.PluCodigo, _actualizarTeclaDirecta.NumeroTeclaDirecta);
        }
        #endregion

        #region Asignar Eliminar Tecla Directa
        public void AsignarEliminarTeclaDirecta()
        {
            eventoEjecutado = NombreEventosEnum.EliminarTeclaDirecta;
            epelsa.Send_Key(_eliminarTeclaDirecta.ProgramarSeccion, _eliminarTeclaDirecta.NumeroSeccion, _eliminarTeclaDirecta.TablaTeclaDirecta, 0, 0, _eliminarTeclaDirecta.NumeroTeclaDirecta);
        }
        #endregion

        private bool ValidarSiExistePlu(int codigoPlu, int numeroTeclaDirecta)
        {
            return Articulo.Equals(codigoPlu, numeroTeclaDirecta);
        }

        #region Exportar Tiquetes/Archivo Plano + Actualización Nuevos Tiquetes Generados
        public void GenerarTiquetes()
        {
            eventoEjecutado = NombreEventosEnum.ExportarTiquete;
            var tiquete = epelsa.Query_All_Tickets_Struct(0, @"C:\ticketes\Tiquete_Epelsa.txt");
            var ObservadorArchivo = new FileSystemWatcher();
            //TODO: Implementar método de Leer el peso y los datos obtenidos por el tiquete generado.

            if (ObservadorArchivo != null)
            {
                ObservadorArchivo.Changed += Observador_Changed;
                ObservadorArchivo.Path = @"C:\ticketes\";
                ObservadorArchivo.EnableRaisingEvents = true;

                Console.WriteLine("Actualizando archivo...");
                Console.WriteLine("Tiquete guardado correctamente!");
 
                Console.ReadLine();
            }
        }

        private void Observador_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Se ha ingresado un nuevo tiquete - {e.Name}");
        }
        #endregion

        /// <summary>
        /// Éste Método, "Que es recomendable usar cada vez que se han recibido todos los tickets", se borran los datos de totales de las balanzas, quedando límpias sus memorias. 
        /// Sí durante un periodo de tiempo prolongado, no se borran estos datos, la balanza puede quedar llena y por tanto no aceptar la creación de nuevos tickets.
        /// </summary>
        /// “0” --> NO REINICIA
        /// “1” --> REINICIA
        #region Reiniciar Numeración Tiquete/Inicio del Día
        public void ReiniciarNumeracionTiquete(int reiniciar)//ReiniciarTiquete reiniciarTiquete)
        {
            eventoEjecutado = NombreEventosEnum.ReiniciarNumeracionTiquete;
            epelsa.Erase_Totals(1);
            //eventoEjecutado = NombreEventosEnum.ReiniciarNumeracionTiquete;
            //var reinicioTiquete = reiniciarTiquete == ReiniciarTiquete.Reiniciar ? 1 : 0;
        }
        #endregion

        #region Eventos
        private void AgregarEventos()
        {
            epelsa.ComOK += new __Epel_ComOKEventHandler(ComOK);
            epelsa.ComError += new __Epel_ComErrorEventHandler(ComError);
        }
        #endregion

        #region Evento Ejecutado
        private void EventoEjecutado(int? Error_Code)
        {
            string respuesta = Error_Code == null ? "OK" : Error_Code.ToString();

            switch (eventoEjecutado)
            {
                case NombreEventosEnum.AgregarVendedor:

                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    if (Error_Code == null)
                    {
                        EnviarVendedor(VendedorEpelsa);
                    }
                    VendedorEpelsa = new VendedorEpelsa();
                    break;
                case NombreEventosEnum.ConfigurarBalanza:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ActualizarVendedor:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.EliminarVendedor:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ConsultarVendedor:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.AgregarArticulo:
                    // MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    AsignarNuevaTeclaDirecta();
                    break;
                case NombreEventosEnum.AgregarTeclaDirecta:
                    MostrarMensajeEvento($"{NombreEventosEnum.AgregarArticulo.ToString()} Y {eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ActualizarArticulo:
                    MostrarMensajeEvento($"{NombreEventosEnum.ActualizarArticulo.ToString()} Y {eventoEjecutado.ToString()} {respuesta}");
                    //AsignarEliminarTeclaDirecta();
                    break;
                case NombreEventosEnum.ActualizarTeclaDirecta:
                    MostrarMensajeEvento($"{NombreEventosEnum.ActualizarArticulo.ToString()} Y {eventoEjecutado.ToString()} {respuesta}");
                    AsignarActualizarTeclaDirecta();
                    break;
                case NombreEventosEnum.EliminarArticulo:
                    AsignarEliminarTeclaDirecta();
                    break;
                case NombreEventosEnum.EliminarTeclaDirecta:
                    MostrarMensajeEvento($"{NombreEventosEnum.EliminarArticulo.ToString()} Y {eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ConsultarArticulos:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ExportarTiquete:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
                case NombreEventosEnum.ReiniciarNumeracionTiquete:
                    MostrarMensajeEvento($"{eventoEjecutado.ToString()} {respuesta}");
                    break;
            }
        }
        #endregion
    }
}