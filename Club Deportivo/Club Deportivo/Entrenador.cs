using System;
using System.Collections;

public class Entrenador : Persona
{
    private ArrayList deportesEntrenados;

    public Entrenador(int edad, string nombre, int dni) : base(edad, nombre, dni)
    {
        deportesEntrenados = new ArrayList();
    }

    public ArrayList DeportesEntrenados
    {
        get { return deportesEntrenados; }
    }

    public void AgregarDeporte(Deporte deporte)
    {
        // Verificar si el deporte ya está en la lista
        if (!deportesEntrenados.Contains(deporte))
        {
            deportesEntrenados.Add(deporte);
        }
    }

    public void VerDeportesEntrenados()
    {
        Console.WriteLine("Deportes entrenados por " + Nombre + ":");
        foreach (Deporte d in deportesEntrenados)
        {
            Console.WriteLine("- " + d.NombreDeporte);
        }
    }
}
