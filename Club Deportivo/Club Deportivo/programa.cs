using System;
using System.Collections;
using System.Collections.Generic;

namespace clases
{
    class Program
    {
        static void Main(string[] args)
        {
            ClubDeportivo club = datosCargados();

            while (true)
            {
                Console.Clear();
                string opcion = menuInfo();
                if (opcion == "0")
                {
                    break;
                }
                Menu(club, opcion);
                Console.ReadKey();
            }
        }

		static public ClubDeportivo datosCargados() {

			ArrayList listDeportes = new ArrayList();
			ArrayList listSocio = new ArrayList();

			// (int edad, string nombre, int dni)
			Entrenador entrador1 = new Entrenador(21, "Eliana", 12345678);
			Entrenador entrador2 = new Entrenador(23, "Pedro", 345678);

			// (string nombreDeporte, int categoria, Entrenador entrenador, int cupo, int cantidadInscriptos, double costo, string horario, int descuento, int id)
			Deporte deporte1 = new Deporte("tenis", 2001, entrador1, 20, 0, 8000, "jueves de 18 a 20hs", 15, 3333);
			Deporte deporte2 = new Deporte("voley", 2005, entrador2, 60, 0, 8000, "jueves de 18 a 20hs", 15, 3335);

			listDeportes.Add(deporte1);
			listDeportes.Add(deporte2);
			


			//(int edad, string nombre, int dni, ArrayList referenciasDeportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado)
			ArrayList referenciasDeportes = new ArrayList();
			ArrayList nombresDeDeportesAnotado = new ArrayList();
			Socio socio = new Socio(22, "Eliana", 1, referenciasDeportes, 2001, 6, nombresDeDeportesAnotado);
			socio.NombresDeDeportesAnotado.Add(deporte1.NombreDeporte);
			socio.ReferenciasDeportes.Add(deporte1.Id);
			listSocio.Add(socio);
			deporte1.CantidadInscriptos++;


			ClubDeportivo club = new ClubDeportivo(listSocio, listDeportes);
			return club;
		}

		static public string menuInfo()
		{
		    Console.WriteLine("========== MENÚ PRINCIPAL ==========");
		    Console.WriteLine("1. Registrar nuevo entrenador");
		    Console.WriteLine("2. Eliminar entrenador existente");
		    Console.WriteLine("3. Añadir nuevo socio");
		    Console.WriteLine("4. Eliminar socio registrado");
		    Console.WriteLine("5. Simular el pago de una cuota");
		    Console.WriteLine("A. Opciones de inscripción:");
		    Console.WriteLine("6. Ver lista de socios deudores");
		    Console.WriteLine("7. Añadir nuevo deporte");
		    Console.WriteLine("8. Eliminar deporte existente");
		    Console.WriteLine("9. Mostrar listado de deportes");
		    Console.WriteLine("0. Salir del sistema");
		    Console.WriteLine("====================================");
		    
		    Console.Write("Por favor, seleccione una opción: ");
		    string opcion = Console.ReadLine();
		    return opcion;
		}
		
		
		static public void Menu(ClubDeportivo club, string opcion)
		{
		    try
		    {
		        switch (opcion)
		        {
		            case "1":
		                AñadirEntrenador(club);
		                break;
		            case "2":
		                EliminarEntrenador(club);
		                break;
		            case "3":
		                AñadirSocio(club);
		                break;
		            case "4":
		                EliminarSocio(club);
		                break;
		            case "5":
		                PagarCuota(club);
		                break;
		            case "a":
		                MostrarOpcionesListadoInscriptos();
		                int opcion2 = int.Parse(Console.ReadLine());
		                EjecutarOpcionListadoInscriptos(club, opcion2);
		                break;
		            case "6":
		                ImprimirDeudoresSiExisten(club);
		                break;
		            case "7":
		                AgregarDeporte(club);
		                break;
		            case "8":
		                EliminarDeporte(club);
		                break;
		            case "9":
		                ListadoDeportes(club);
		                break;
		            case "0":
		                Environment.Exit(0);
		                break;
		            default:
		                Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
		                break;
		        }
		    }
		    catch (FormatException ex)
		    {
		        Console.WriteLine("Error de formato: " + ex.Message);
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine("Ha ocurrido un error: " + ex.Message);
		    }
		}
		
		static private void MostrarOpcionesListadoInscriptos()
		{
		    Console.WriteLine("Ingrese una opción:");
		    Console.WriteLine("1 - Por deporte");
		    Console.WriteLine("2 - Por deporte y categoría");
		    Console.WriteLine("3 - Total");
		}
		
		static private void EjecutarOpcionListadoInscriptos(ClubDeportivo club, int opcion)
		{
		    switch (opcion)
		    {
		        case 1:
		            ListarInscriptosPorDeporte(club);
		            break;
		        case 2:
		            ListarInscriptosPorDeporteYCategoría(club);
		            break;
		        case 3:
		            ImprimirTotalInscriptos(club);
		            break;
		        default:
		            Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
		            break;
		    }
		}
		
		static private void ImprimirDeudoresSiExisten(ClubDeportivo club)
		{
		    if (club.ListSocio == null || club.ListSocio.Count == 0)
		    {
		        Console.WriteLine("La lista está vacía.");
		    }
		    else
		    {
		        ImprimirDeudores(club);
		    }
		}
				
		
		static public void ListadoDeportes(ClubDeportivo club)
		{
			Console.Clear();
		    if (club.ListDeportes == null || club.ListDeportes.Count == 0)
		    {
		        Console.ForegroundColor = ConsoleColor.Yellow;
		        Console.WriteLine("No hay deportes registrados actualmente.");
		        Console.ResetColor();
		        return;
		    }
		
		    Console.WriteLine("========== LISTADO DE DEPORTES ==========");
		    foreach (Deporte deporte in club.ListDeportes)
		    {
		        Console.WriteLine("----------------------------------------");
		        Console.ForegroundColor = ConsoleColor.Cyan;
		        Console.WriteLine("Deporte: " + deporte.NombreDeporte.ToUpper());
		        Console.ResetColor();
		        Console.WriteLine("Horario: " + deporte.Horario);
		        Console.WriteLine("Categoría: " + deporte.Categoria);
		        Console.WriteLine("Cupos disponibles: " + deporte.Cupo);
		        Console.WriteLine("Personas inscriptas: " + deporte.CantidadInscriptos);
		        Console.WriteLine("Entrenador: " + (deporte.Entrenador != null ? deporte.Entrenador.Nombre : "No asignado"));
		        Console.WriteLine("Costo: $" + deporte.Costo.ToString("F2"));
		    }
		    Console.WriteLine("=========================================");
		}

        
		static public void AñadirEntrenador(ClubDeportivo club)
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Agregar Entrenador =====");
		    Console.ResetColor();
		
		    Console.Write("Ingrese el nombre y apellido del entrenador: ");
		    string nombreEntrenador = Console.ReadLine();
		
		    Console.Write("Ingrese la edad del entrenador: ");
		    int edad = int.Parse(Console.ReadLine());
		
		    Console.Write("Ingrese el DNI del entrenador: ");
		    int dni = int.Parse(Console.ReadLine());
		
		    Entrenador entrenador = new Entrenador(edad, nombreEntrenador, dni);
		
		    Console.Write("Ingrese el nombre del deporte para agregar entrenador: ");
		    string nombreDeporte = Console.ReadLine();
		
		    Deporte deporteEncontrado = null;
		
		    foreach (Deporte d22 in club.ListDeportes)
		    {
		        if (d22.NombreDeporte.Equals(nombreDeporte, StringComparison.OrdinalIgnoreCase))
		        {
		            deporteEncontrado = d22;
		            break;
		        }
		    }
		
		    if (deporteEncontrado != null)
		    {
		        if (deporteEncontrado.Entrenador == null) // Verifica si ya hay un entrenador asignado
		        {
		            deporteEncontrado.AgregarEntrenador(entrenador);
		            Console.ForegroundColor = ConsoleColor.Green;
		            Console.WriteLine();
		            Console.WriteLine("El entrenador ha sido agregado exitosamente al deporte: " + nombreDeporte);
		        }
		        else
		        {
		            Console.ForegroundColor = ConsoleColor.Red;
		            Console.WriteLine();
		            Console.WriteLine("Actualmente, ya hay un entrenador asignado al deporte: " + nombreDeporte);
		        }
		    }
		    else
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine();
		        Console.WriteLine("No se ha encontrado el deporte especificado en la lista.");
		    }
		
		    Console.ResetColor();
		    Console.WriteLine();
		    Console.WriteLine("Presione cualquier boton para volver al menú principal.");
		
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("==============================");
		    Console.ResetColor();
		}

		static void EliminarEntrenador(ClubDeportivo club)
		{
		    bool entrenadorEncontrado = false;
		
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Eliminar Entrenador =====");
		    Console.ResetColor();
		
		    Console.Write("Ingrese el DNI del entrenador que desea eliminar: ");
		    int dni = int.Parse(Console.ReadLine());
		
		    foreach (Deporte deporte in club.ListDeportes)
		    {
		        if (deporte.Entrenador != null && deporte.Entrenador.Dni == dni)
		        {
		            entrenadorEncontrado = true;
		            if (deporte.CantidadInscriptos == 0)
		            {
		                Console.ForegroundColor = ConsoleColor.Green;
		                Console.WriteLine("\nEl entrenador ha sido eliminado con éxito.");
		                Console.ResetColor();
		
		                Console.WriteLine("Información del Entrenador:");
		                Console.WriteLine("DNI: " + deporte.Entrenador.Dni);
		                Console.WriteLine("Nombre: " + deporte.Entrenador.Nombre);
		                Console.WriteLine("Edad: " + deporte.Entrenador.Edad);
		
		                deporte.Entrenador = null;
		                return;
		            }
		            else
		            {
		                Console.ForegroundColor = ConsoleColor.Red;
		                Console.WriteLine("\nNo se puede eliminar el entrenador porque hay personas inscritas en el deporte.");
		                Console.ResetColor();
		                return;
		            }
		        }
		    }
		
		    if (!entrenadorEncontrado)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("\nNo se encontró un entrenador con el DNI ingresado.");
		        Console.ResetColor();
		    }
		
		    Console.WriteLine("");
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("==============================\n");
		    Console.ResetColor();
		}

        
		static public void AñadirSocio(ClubDeportivo club)
		{
			
		    // Solicitar datos del nuevo socio
		    Socio socio = pedirDatosSocio(club);
		
		
		    Console.Write("Ingrese el nombre del deporte al que desea inscribirse: ");
		    string nombreDeporte = Console.ReadLine();
		
		    // Verificar si el DNI ya existe en la base de datos de socios o entrenadores
		    var socioEncontrado = club.BuscarSocio(socio.Dni);
		    var entrenadorEncontrado = club.BuscarEntrenador(socio.Dni);
		
		    if (socioEncontrado != null || entrenadorEncontrado != null)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("\nEl DNI ingresado ya existe en la base de datos.");
		        Console.ResetColor();
		        return;
		    }
		
		    try
		    {
		        // Buscar el deporte y verificar la disponibilidad de cupo
		        foreach (Deporte deporte in club.ListDeportes)
		        {
		            // Verificar coincidencia de nombre y categoría del deporte
		            if (deporte.NombreDeporte.Equals(nombreDeporte, StringComparison.OrdinalIgnoreCase) && socio.Categoria == deporte.Categoria)
		            {
		                if (deporte.Cupo <= 0)
		                {
		                    throw new ExceptionCupoSocio("No hay cupos disponibles para el deporte seleccionado.");
		                }
		                else
		                {
		                    // Agregar socio al club y actualizar datos del deporte
		                    club.AgregarSocio(socio);
		                    socio.ReferenciasDeportes.Add(deporte.Id);
		                    socio.NombresDeDeportesAnotado.Add(deporte.NombreDeporte);
		                    deporte.Cupo--;
		                    deporte.CantidadInscriptos++;
		
		                    Console.ForegroundColor = ConsoleColor.Green;
		                    Console.WriteLine("\nEl socio se ha inscrito correctamente al deporte elegido");
		                    Console.WriteLine("Horario del Deporte: " + deporte.Horario);
		                    Console.ResetColor();
		                    return;
		                }
		            }
		        }
		
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("\nNo se encontró el deporte especificado o la categoría no coincide.");
		        Console.ResetColor();
		    }
		    catch (ExceptionCupoSocio ex)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("\nError: " + ex.Message);
		        Console.ResetColor();
		    }
		
		    Console.WriteLine("");
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("==============================\n");
		    Console.ResetColor();
		}
				
		static public Socio pedirDatosSocio(ClubDeportivo club)
		{
			Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Registro de Nuevo Socio =====");
		    Console.ResetColor();
		
		    Console.Write("Ingrese la edad del socio: ");
		    int edad = int.Parse(Console.ReadLine());
		
		    Console.Write("Ingrese el nombre completo del socio: ");
		    string nombre = Console.ReadLine();
		
		    Console.Write("Ingrese el DNI del socio: ");
		    int dni = int.Parse(Console.ReadLine());
		
		    ArrayList listaDeportes = new ArrayList();
		    DateTime fechaActual = DateTime.Now;
		    int categoria = fechaActual.Year - edad;
		    ArrayList nombresDeportes = new ArrayList();
		
		    Socio socio = new Socio(edad, nombre, dni, listaDeportes, categoria, fechaActual.Month, nombresDeportes);
		
		    Console.ForegroundColor = ConsoleColor.Green;
		    Console.WriteLine("\nDatos del socio registrados correctamente.");
		    Console.ResetColor();
		    Console.WriteLine("=====================================\n");
		
		    return socio;
		}
				
		
		static public void EliminarSocio(ClubDeportivo club)
		{
		    Console.WriteLine("Ingrese el DNI del socio a eliminar:");
		    int dni = int.Parse(Console.ReadLine());
		    foreach (Socio s17 in club.ListSocio)
		    {
		        if (s17.Dni == dni)
		        {
		            DateTime fechaActual = DateTime.Now;
		            if (s17.MesPago < fechaActual.Month)
		            {
		                Console.ForegroundColor = ConsoleColor.Red;
		                Console.WriteLine("No se puede dar de baja, el socio tiene deuda de " + (fechaActual.Month - s17.MesPago + " Mes(es)"));
		                Console.ResetColor();
		                return;
		            }
		            foreach (int referencias4 in s17.ReferenciasDeportes)
		            {
		                foreach (Deporte d25 in club.ListDeportes)
		                {
		                    if (d25.Id == referencias4)
		                    {
		                        d25.Cupo++;
		                        d25.CantidadInscriptos--;
		                    }
		                }
		            }
		            club.ListSocio.Remove(s17);
		            Console.ForegroundColor = ConsoleColor.Green;
		            Console.WriteLine("Se eliminó correctamente al socio.");
		            Console.ResetColor();
		            return;
		        }
		    }
		    Console.ForegroundColor = ConsoleColor.Red;
		    Console.WriteLine("No se encontró el socio especificado.");
		    Console.ResetColor();
		}
		
		
		static public void PagarCuota(ClubDeportivo club)
		{
			Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Pago de Cuota Mensual =====");
		    Console.ResetColor();
		
		    Console.Write("Ingrese el DNI del socio: ");
		    int dni = int.Parse(Console.ReadLine());
		
		    Console.Write("Ingrese el nombre del deporte: ");
		    string nombreDeporte = Console.ReadLine();
		
		    DateTime fechaActual = DateTime.Now;
		
		    foreach (Socio socio in club.ListSocio)
		    {
		        if (socio.Dni == dni)
		        {
		            foreach (Deporte deporte in club.ListDeportes)
		            {
		                if (deporte.NombreDeporte.Equals(nombreDeporte, StringComparison.OrdinalIgnoreCase))
		                {
		                    foreach (int referencia in socio.ReferenciasDeportes)
		                    {
		                        if (referencia == deporte.Id)
		                        {
		                            try
		                            {
		                                double costo = deporte.Costo;
		                                double descuentoAplicado = (costo / 100) * deporte.Descuento;
		                                double precioFinal = costo - descuentoAplicado;
		
		                                Console.WriteLine("\nDetalles del Pago:");
		                                Console.WriteLine("------------------------");
		                                Console.WriteLine("Costo original: " + costo.ToString("C"));
		                                Console.WriteLine("Descuento aplicado: " + deporte.Descuento + "%");
		                                Console.WriteLine("Precio final a pagar: " + precioFinal.ToString("C"));
		                                Console.WriteLine("------------------------");
		                                
		                                Console.Write("Ingrese el monto para completar el pago: ");
		                                double monto = double.Parse(Console.ReadLine());
		
		                                // Verificar si el monto es igual al precio final
		                                if (monto == precioFinal)
		                                {
		                                    if (socio.MesPago + 1 > fechaActual.Month)
		                                    {
		                                        Console.ForegroundColor = ConsoleColor.Yellow;
		                                        Console.WriteLine("\nLa cuota del mes ya está pagada. Por favor, espere hasta el próximo mes.");
		                                        Console.ResetColor();
		                                        return;
		                                    }
		
		                                    if (socio.MesPago + 1 == 13)
		                                    {
		                                        socio.MesPago = 0; // Reiniciar el mes si llega a 13
		                                    }
		
		                                    socio.MesPago++;
		                                    Console.ForegroundColor = ConsoleColor.Green;
		                                    Console.WriteLine("\n¡Pago realizado con éxito! Su cuota ha sido pagada correctamente.");
		                                    Console.ResetColor();
		                                    return;
		                                }
		                                else
		                                {
		                                    throw new Exception("El monto ingresado no coincide con el costo de la cuota. Verifique e intente nuevamente.");
		                                }
		                            }
		                            catch (Exception ex)
		                            {
		                                Console.ForegroundColor = ConsoleColor.Red;
		                                Console.WriteLine("\nError: " + ex.Message);
		                                Console.ResetColor();
		                                return;
		                            }
		                        }
		                    }
		                }
		            }
		            Console.ForegroundColor = ConsoleColor.Red;
		            Console.WriteLine("\nEl deporte especificado no se encuentra en el sistema.");
		            Console.ResetColor();
		            return;
		        }
		    }
		
		    Console.ForegroundColor = ConsoleColor.Red;
		    Console.WriteLine("\nEl socio especificado no se encuentra en la base de datos.");
		    Console.ResetColor();
		}

		public static void ListarInscriptosPorDeporte(ClubDeportivo club)
		{
			Console.Clear(); 
		    var deportesImpresos = new HashSet<string>();
		
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Listado de Socios por Deporte =====");
		    Console.ResetColor();
		
		    foreach (Deporte deporte in club.ListDeportes)
		    {
		        // Evitar duplicados en la impresión de deportes
		        if (deportesImpresos.Contains(deporte.NombreDeporte))
		            continue;
		
		        deportesImpresos.Add(deporte.NombreDeporte);
		
		        Console.WriteLine("\n-----------------------");
		        Console.ForegroundColor = ConsoleColor.Yellow;
		        Console.WriteLine("Deporte: " + deporte.NombreDeporte);
		        Console.ResetColor();
		
		        bool sociosEncontrados = false;
		
		        foreach (Socio socio in club.ListSocio)
		        {
		            if (socio.NombresDeDeportesAnotado.Contains(deporte.NombreDeporte))
		            {
		                Console.WriteLine("Nombre: " + socio.Nombre + " | Edad: " + socio.Edad);
		                sociosEncontrados = true;
		            }
		        }
		
		        if (!sociosEncontrados)
		        {
		            Console.ForegroundColor = ConsoleColor.Cyan;
		            Console.WriteLine("No hay socios inscritos en este deporte.");
		            Console.ResetColor();
		        }
		    }
		
		    Console.WriteLine("\n=========================================\n");
		}

		
		static public void ListarInscriptosPorDeporteYCategoría(ClubDeportivo club)
		{
			Console.Clear();
		    foreach (Deporte d19 in club.ListDeportes)
		    {
		        Console.WriteLine("-----------------------");
		        Console.ForegroundColor = ConsoleColor.Yellow;
		        Console.WriteLine("Deporte: " + d19.NombreDeporte + " | Categoría: " + d19.Categoria);
		        Console.ResetColor();
		
		        bool sociosEncontrados = false;
		
		        foreach (Socio s19 in club.ListSocio)
		        {
		            foreach (int referencia2 in s19.ReferenciasDeportes)
		            {
		                if (d19.Id == referencia2)
		                {
		                    Console.WriteLine("Nombre: " + s19.Nombre + " | Edad: " + s19.Edad);
		                    sociosEncontrados = true;
		                }
		            }
		        }
		
		        if (!sociosEncontrados)
		        {
		            Console.ForegroundColor = ConsoleColor.Cyan;
		            Console.WriteLine("No hay socios inscritos en este deporte para la categoría indicada.");
		            Console.ResetColor();
		        }
		
		        Console.WriteLine("-----------------------\n");
		    }
		}


		static public void ImprimirTotalInscriptos(ClubDeportivo club)
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Yellow;
		    Console.WriteLine("-------- Total de Inscritos --------");
		    Console.ResetColor();
		
		    if (club.ListSocio.Count == 0)
		    {
		        Console.ForegroundColor = ConsoleColor.Cyan;
		        Console.WriteLine("No hay socios inscritos en el club.");
		        Console.ResetColor();
		        return;
		    }
		
		    foreach (Socio s3 in club.ListSocio)
		    {
		        Console.WriteLine("Nombre: {0} | DNI: {1} | Edad: {2}", s3.Nombre, s3.Dni, s3.Edad);
		    }
		
		    Console.WriteLine("-------------------------------------");
		    Console.WriteLine("Total de inscritos: {0}", club.ListSocio.Count);
		}

        
		static public void ImprimirDeudores(ClubDeportivo club)
		{
			Console.Clear();
		    DateTime fechaActual = DateTime.Now;
		    bool hayDeudores = false;
		
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Red;
		    Console.WriteLine("--------- Deudores ---------");
		    Console.ResetColor();
		
		    foreach (Socio s4 in club.ListSocio)
		    {
		        if (fechaActual.Month > s4.MesPago)
		        {
		            Console.WriteLine("Nombre: {0} | DNI: {1} | Edad: {2}", s4.Nombre, s4.Dni, s4.Edad);
		            hayDeudores = true;
		        }
		    }
		
		    if (!hayDeudores)
		    {
		        Console.ForegroundColor = ConsoleColor.Green;
		        Console.WriteLine("No hay deudores.");
		        Console.ResetColor();
		    }
		    else
		    {
		        Console.WriteLine("---------------------------");
		    }
		
		    Console.WriteLine("\n----- Próximos a Pagar -----");
		    bool hayPróximos = false;
		
		    foreach (Socio s4 in club.ListSocio)
		    {
		        if (fechaActual.Month == s4.MesPago)
		        {
		            Console.WriteLine("Nombre: {0} | DNI: {1} | Edad: {2}", s4.Nombre, s4.Dni, s4.Edad);
		            hayPróximos = true;
		        }
		    }
		
		    if (!hayPróximos)
		    {
		        Console.ForegroundColor = ConsoleColor.Cyan;
		        Console.WriteLine("No hay socios próximos a pagar.");
		        Console.ResetColor();
		    }
		
		    Console.WriteLine("---------------------------");
		}

		
		static public void AgregarDeporte(ClubDeportivo club)
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("------- Agregar Deporte -------");
		    Console.ResetColor();
		
		    Console.Write("Ingrese el nombre del deporte: ");
		    string nombreDeporte = Console.ReadLine();
		
		    try
		    {
		        Console.Write("Ingrese la categoría (año): ");
		        int categoria = int.Parse(Console.ReadLine());
		        
		        Console.WriteLine();
		        Console.WriteLine("Ingrese los datos del entrenador para el deporte:");
		        Entrenador entrenador = PedirDatos();
		
		        Console.Write("Ingrese la cantidad de cupos del deporte: ");
		        int cupo = int.Parse(Console.ReadLine());
		
		        Console.Write("Ingrese el costo del deporte: ");
		        double costo = double.Parse(Console.ReadLine());
		
		        Console.Write("Ingrese el horario del deporte: ");
		        string horario = Console.ReadLine();
		
		        Console.Write("Ingrese el descuento para socios (%): ");
		        int descuento = int.Parse(Console.ReadLine());
		
		        Console.Write("Ingrese el ID del deporte: ");
		        int id = int.Parse(Console.ReadLine());
		
		        // Crear una nueva instancia de Deporte
		        Deporte deporte = new Deporte(nombreDeporte, categoria, entrenador, cupo, 0, costo, horario, descuento, id);
		
		        // Agregar el deporte al club
		        club.AgregarDeporte(deporte);
		
		        Console.ForegroundColor = ConsoleColor.Green;
		        Console.WriteLine("El deporte se agregó correctamente.");
		        Console.ResetColor();
		    }
		    catch (FormatException ex)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("Error de formato: " + ex.Message);
		        Console.ResetColor();
		    }
		    catch (Exception ex)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("Ha ocurrido un error: " + ex.Message);
		        Console.ResetColor();
		    }
		}

		
		static public Entrenador PedirDatos()
		{

		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("------- Ingresar Datos del Entrenador -------");
		    Console.ResetColor();
		
		    Console.Write("Ingrese su nombre: ");
		    string nombre = Console.ReadLine();
		
		    int edad;
		    int dni;
		
		    try
		    {
		        Console.Write("Ingrese su edad: ");
		        string edadTexto = Console.ReadLine();
		        
		        if (!int.TryParse(edadTexto, out edad) || edad <= 0)
		        {
		            throw new ExceptionEdadInvalida("La edad ingresada es inválida. Debe ser un número positivo.");
		        }
		
		        Console.Write("Ingrese su DNI: ");
		        string dniTexto = Console.ReadLine();
		        
		        if (!int.TryParse(dniTexto, out dni) || dni <= 0)
		        {
		            throw new ExceptionDniInvalido("El DNI ingresado es inválido. Debe ser un número positivo.");
		        }
		
		        // Crear y devolver una nueva instancia de Entrenador
		        Entrenador entrenador = new Entrenador(dni, nombre, edad);
		        return entrenador;
		    }
		    catch (ExceptionEdadInvalida ex)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine(ex.Message);
		        Console.ResetColor();
		    }
		    catch (ExceptionDniInvalido ex2)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine(ex2.Message);
		        Console.ResetColor();
		    }
		
		    return null;
		}

		static public void EliminarDeporte(ClubDeportivo club)
		{
			Console.Clear();
		    Console.ForegroundColor = ConsoleColor.Cyan;
		    Console.WriteLine("===== Eliminar Deporte =====");
		    Console.ResetColor();
		    
		    Console.WriteLine("Ingrese el nombre del deporte que desea eliminar:");
		    string nombreDeporte = Console.ReadLine();
		
		    Console.WriteLine("Ingrese la categoría del deporte a eliminar:");
		    int categoria;
		
		    // Intentar parsear la categoría
		    try
		    {
		        categoria = int.Parse(Console.ReadLine());
		    }
		    catch (FormatException)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("La categoría ingresada no es válida.");
		        Console.ResetColor();
		        return;
		    }
		
		    // Buscar el deporte en la lista
		    Deporte deporteAEliminar = null;
		    foreach (Deporte d in club.ListDeportes)
		    {
		        if (d.NombreDeporte.Equals(nombreDeporte, StringComparison.OrdinalIgnoreCase) && d.Categoria == categoria)
		        {
		            deporteAEliminar = d;
		            break;
		        }
		    }
		
		    // Comprobar si se encontró el deporte
		    if (deporteAEliminar == null)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("No se encontró el deporte especificado.");
		        Console.ResetColor();
		        return;
		    }
		
		    // Verificar si hay inscriptos
		    if (deporteAEliminar.CantidadInscriptos > 0)
		    {
		        Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine("Hay inscriptos en este deporte, no se puede eliminar.");
		        Console.ResetColor();
		        return;
		    }
		
		    // Eliminar el deporte
		    club.ListDeportes.Remove(deporteAEliminar);
		    Console.ForegroundColor = ConsoleColor.Green;
		    Console.WriteLine("El deporte se eliminó correctamente.");
		    Console.ResetColor();
		}
			
    }
}