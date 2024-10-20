using System;
using System.Collections;

public class Socio : Persona
{
    private ArrayList referenciasDeportes;
    private ArrayList nombresDeDeportesAnotado;
    private int categoria;
    private int mesPago;

    public Socio(int edad, string nombre, int dni, ArrayList referenciasDeportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado) 
        : base(edad, nombre, dni)
    {
        this.nombresDeDeportesAnotado = nombresDeDeportesAnotado != null ? nombresDeDeportesAnotado : new ArrayList();
        this.referenciasDeportes = referenciasDeportes != null ? referenciasDeportes : new ArrayList();
        this.categoria = categoria;
        this.mesPago = mesPago;
    }

    public ArrayList ReferenciasDeportes
    {
        get { return referenciasDeportes; }
    }

    public ArrayList NombresDeDeportesAnotado
    {
        get { return nombresDeDeportesAnotado; }
    }

    public int Categoria
    {
        get { return categoria; }
        set { categoria = value; }
    }

    public int MesPago
    {
        get { return mesPago; }
        set { mesPago = value; }
    }

    public void EliminarNombreDeporteIndex(int i)
    {
        if (i >= 0 && i < nombresDeDeportesAnotado.Count)
        {
            nombresDeDeportesAnotado.RemoveAt(i);
        }
    }

    public void EliminarReferenciaDeporte(int i)
    {
        if (i >= 0 && i < referenciasDeportes.Count)
        {
            referenciasDeportes.RemoveAt(i);
        }
    }

    public int ObtenerReferenciaDeporte(int i)
    {
        if (i >= 0 && i < referenciasDeportes.Count)
        {
            return (int)referenciasDeportes[i];
        }
        throw new IndexOutOfRangeException("Índice fuera de rango");
    }

    public string ObtenerNombreDeporte(int i)
    {
        if (i >= 0 && i < nombresDeDeportesAnotado.Count)
        {
            return (string)nombresDeDeportesAnotado[i];
        }
        throw new IndexOutOfRangeException("Índice fuera de rango");
    }

    public bool EsVacioReferenciaDeporte()
    {
        return referenciasDeportes.Count == 0;
    }

    public bool EsVacioNombreDeportes()
    {
        return nombresDeDeportesAnotado.Count == 0;
    }

    public int TotalReferenciaDeporte()
    {
        return referenciasDeportes.Count;
    }

    public int TotalNombreDeporte()
    {
        return nombresDeDeportesAnotado.Count;
    }

    public ArrayList VerReferenciaDeportes()
    {
        return referenciasDeportes;
    }

    public ArrayList VerNombreDeporte()
    {
        return nombresDeDeportesAnotado;
    }
}
