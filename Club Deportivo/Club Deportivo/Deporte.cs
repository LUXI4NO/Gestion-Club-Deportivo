using System;

public class Deporte
{
    private string nombreDeporte;
    private int categoria;
    private Entrenador entrenador;
    private int cupo;
    private int cantidadInscriptos;
    private double costo;
    private string horario;
    private int descuento;
    private int id;

    public Deporte(string nombreDeporte, int categoria, Entrenador entrenador, int cupo, int cantidadInscriptos, double costo, string horario, int descuento, int id)
    {
        NombreDeporte = nombreDeporte; 
        Categoria = categoria;          
        Entrenador = entrenador;       
        Cupo = cupo;                    
        CantidadInscriptos = cantidadInscriptos; 
        Costo = costo;                 
        Horario = horario;              
        Descuento = descuento;         
        Id = id;                        
    }

    public void AgregarEntrenador(Entrenador entrenador)
    {
        Entrenador = entrenador;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public int Descuento
    {
        get { return descuento; }
        set { descuento = value < 0 ? 0 : value; } // Asegura que el descuento no sea negativo
    }

    public string NombreDeporte
    {
        get { return nombreDeporte; }
        set { nombreDeporte = value; }
    }

    public int Categoria
    {
        get { return categoria; }
        set { categoria = value; }
    }

    public Entrenador Entrenador
    {
        get { return entrenador; }
        set { entrenador = value; }
    }

    public int Cupo
    {
        get { return cupo; }
        set { cupo = value >= 0 ? value : 0; } // Asegura que el cupo no sea negativo
    }

    public int CantidadInscriptos
    {
        get { return cantidadInscriptos; }
        set { cantidadInscriptos = value >= 0 ? value : 0; } // Asegura que la cantidad de inscriptos no sea negativa
    }

    public string Horario
    {
        get { return horario; }
        set { horario = value; }
    }

    public double Costo
    {
        get { return costo; }
        set { costo = value >= 0 ? value : 0; } // Asegura que el costo no sea negativo
    }

    public bool Inscribir()
    {
        if (cantidadInscriptos < cupo)
        {
            cantidadInscriptos++;
            return true; // Inscripción exitosa
        }
        return false; // No hay cupo disponible
    }
}
