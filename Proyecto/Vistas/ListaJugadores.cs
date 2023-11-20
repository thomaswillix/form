﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Manejadores;


namespace Practica1
{
    public partial class ListaJugadores : Form
    {
        private Jugador e;
        private int a = 0;
        private DateTime d;

        public ListaJugadores()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            ControladorJugadores.leerJugadoresXML();
        }
        /*private void cargarEmpleados()
        {
            d = new DateTime(1986, 7, 2, 0, 0, 0);
            e = new Jugador(1,"Bruno","Rezende","Bruno", "Colocador", 'H',d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(1991, 2, 27, 0, 0, 0);
            e = new Jugador(4, "Otávio Henrique", "Rodrigues Pinto", "Otávio", "Bloqueador Central", 'H' ,d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(2002, 2, 6, 0, 0, 0);
            e = new Jugador(6, "Adriano", "Fernandes P.X.Calvante", "Adriano", "Opuesto", 'H', d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(1997, 3, 18, 0, 0, 0);
            e = new Jugador(8, "Henrique", "Dantas Nóbrega Honorato", "Honorato", "Opuesto", 'H', d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(1997, 7, 16, 0, 0, 0);
            e = new Jugador(15, "Maique", "Reis Nascimento", "Nascimento", "Libero", 'H', d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(1993, 4, 22, 0, 0, 0);
            e = new Jugador(23, "Flavio", "Resende Gualberto", "Flavio", "Bloqueador Central", 'H', d);
            ControladorJugadores.listaJugadores.Add(e);
            d = new DateTime(1996, 1, 13, 0, 0, 0);
            e = new Jugador(14, "Fernando", "Gil Kreling", "Fernando", "Colocador", 'H', d);
            ControladorJugadores.listaJugadores.Add(e);
        }*/

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void crearChecked(string e, int posicion)
        {
            System.Windows.Forms.CheckBox cb = new System.Windows.Forms.CheckBox();
            cb.AutoSize = true;
            cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
            ((byte)(0)));
            cb.Location = new System.Drawing.Point(75, posicion);
            cb.Size = new System.Drawing.Size(291, 20);
            cb.TabIndex = 1;
            cb.Text = e;
            groupBox1.Controls.Add(cb);
        }

        private void mostrarEmpleados()
        {
            int posicion = 10;
            foreach (Jugador e in ControladorJugadores.listaJugadores)
            {
                crearChecked(e.Nombre ,posicion);
                posicion += 30;
            }
        }

        private void ordenarEmpleados(Func<Jugador, IComparable> aux)
        {
            ControladorJugadores.listaJugadores = ControladorJugadores.listaJugadores.OrderBy(aux).ToList();

        }

        private void ordenarFecha_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();

            ordenarEmpleados(Empleado => Empleado.FechaNac);
            mostrarEmpleados();
        }

        private void ordenarNombre_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            ordenarEmpleados(Empleado => Empleado.Nombre);
            mostrarEmpleados();
        }

        private void btElim_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.CheckBox cd in groupBox1.Controls)
            {
                if (cd.Checked)
                {
                    int posicion = ControladorJugadores.listaJugadores.FindIndex(x => x.Nombre == cd.Text);
                    ControladorJugadores.listaJugadores.RemoveAt(posicion);
                }
            }
            this.groupBox1.Controls.Clear();
            mostrarEmpleados();
        }

        private void botonImprimir_Click(object sender, EventArgs e)
        {
            cargarEmpleados();
            a ++;
            mostrarEmpleados();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
