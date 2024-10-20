﻿using System.Collections;
using System;

namespace clases{
	public class ClubDeportivo
	{
		private ArrayList listSocio = new ArrayList();
		private ArrayList listDeportes = new ArrayList();

		public ClubDeportivo(ArrayList listSocio, ArrayList listDeportes)
		{
			this.listDeportes = listDeportes != null ? listDeportes : new ArrayList();
			this.listSocio = listSocio != null ? listSocio : new ArrayList();
		}

		public ArrayList ListSocio
		{
			get { return listSocio; }
		}

        public ArrayList ListDeportes
        {
            get { return listDeportes; }
        }

        public void EliminarDeporteIndex(int i)
        {
            if (i >= 0 && i < listDeportes.Count)
            {
                listDeportes.RemoveAt(i);
            }
        }

        public void EliminarSocio(int i)
        {
            if (i >= 0 && i < listSocio.Count)
            {
                listSocio.RemoveAt(i);
            }
        }

        public Deporte ObtenerDeporteIndex(int i)
        {
            if (i >= 0 && i < listDeportes.Count)
                return (Deporte)listDeportes[i];
            return null;
        }

        public Socio ObtenerSocioIndex(int i)
        {
            if (i >= 0 && i < listSocio.Count)
                return (Socio)listSocio[i];
            return null;
        }

        public bool EsVaciaListaSocio()
        {
            return listSocio.Count == 0;
        }

        public bool EsVaciaListaDeporte()
        {
            return listDeportes.Count == 0;
        }

        public int TotalListaDeportes()
        {
            return listDeportes.Count;
        }

        public int TotalListaSocio()
        {
            return listSocio.Count;
        }

        public ArrayList VerListaDeportes()
        {
            return listDeportes;
        }

        public ArrayList VerListaSocio()
        {
            return listSocio;
        }

        public void AgregarDeporte(Deporte deporte)
        {
            foreach (Deporte d in listDeportes)
            {
                if (d.NombreDeporte == deporte.NombreDeporte)
                {
                    return; // Ya existe el deporte
                }
            }
            listDeportes.Add(deporte);
        }

        public Entrenador BuscarEntrenador(int dni)
        {
            foreach (Deporte d in listDeportes)
            {
                if (d.Entrenador.Dni == dni)
                {
                    return d.Entrenador;
                }
            }
            return null;
        }

        public bool BuscarDeporte(string nombreDelDeporte)
        {
            foreach (Deporte d in listDeportes)
            {
                if (d.NombreDeporte == nombreDelDeporte)
                {
                    return true;
                }
            }
            return false;
        }

        public void AgregarSocio(Socio socio)
        {
            listSocio.Add(socio);
        }

        public Socio BuscarSocio(int dni)
        {
            foreach (Socio s in listSocio)
            {
                if (s.Dni == dni)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
