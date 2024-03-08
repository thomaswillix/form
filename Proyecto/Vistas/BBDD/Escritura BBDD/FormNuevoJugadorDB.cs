﻿using Proyecto.Controladores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto.Vistas
{
    public partial class FormNuevoJugadorDB : Form
    {
        DateTime fechaActual = new DateTime();
        double edadAnios;
        char s;

        public FormNuevoJugadorDB()
        {
            InitializeComponent();
        }

        private void NuevoJugador_Load(object sender, EventArgs e)
        {

        }
        public void calcularEdad()
        {
            fechaActual = DateTime.Now;
            TimeSpan ts = new TimeSpan(fechaActual.Ticks - fechaNac.Value.Ticks);
            edadAnios = (long)(ts.Days / 365);
        }
        public void establecerSexo()
        {
            if (sexo.SelectedItem.ToString() == "Hombre")
            {
                s = 'H';
            }
            else if (sexo.SelectedItem.ToString() == "Mujer")
            {
                s = 'M';
            }
        }
        private bool validar()
        {
            calcularEdad();

            List<string> errores = new List<string>();

            // Realiza todas las validaciones y recopila los mensajes de error
            if (!Validator.validateTextBox(nom))
            {
                errores.Add("El nombre está vacío.");
            }
            if (!Validator.validateTextBox(ape))
            {
                errores.Add("El apellido está vacío.");
            }
            if (!Validator.validateTextBox(nomCami))
            {
                errores.Add("El nombre de la camiseta está vacío.");
            }

            if (!Validator.validateComboBox(sexo))
            {
                errores.Add("El sexo no es válido.");
            }

            if (!Validator.validateComboBox(equipo))
            {
                errores.Add("El equipo no es válido.");
            }

            if (!Validator.validateComboBox(posicion))
            {
                errores.Add("La posición no es válida.");
            }

            if (!Validator.validateNumUpDown(numeroCami))
            {
                errores.Add("El número de la camiseta no es válido.");
            }

            if (edadAnios < 18)
            {
                errores.Add("El jugador no es mayor de edad.");
            }

            // Si hay mensajes de error, imprímelos y devuelve false
            if (errores.Count > 0)
            {
                foreach (var error in errores)
                {
                    Console.WriteLine(error);
                }
                return false;
            }
            // Si no hay errores, devuelve true
            return true;
        }

        private void aniadirJugador()
        {
            establecerSexo();

            JugadoresDAO jugadoresDAO = new JugadoresDAO();
            EquiposDAO equipos = new EquiposDAO();
            int idEquipo = equipos.obtenerId(equipo.Text);
            jugadoresDAO.insertarJugador((int)numeroCami.Value, nom.Text, ape.Text, nomCami.Text, posicion.Text,
                s, fechaNac.Value, idEquipo);
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                aniadirJugador();
                MessageBox.Show("Jugador añadido al fichero de Jugadores");

            }
            else
            {
                MessageBox.Show("Revisa los campos, hay algún dato erróneo");
            }
        }

        private void FormNuevoJugadorDB_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'databaseDataSet.Equipos' Puede moverla o quitarla según sea necesario.
            this.equiposTableAdapter.Fill(this.databaseDataSet.Equipos);

        }
    }
}
