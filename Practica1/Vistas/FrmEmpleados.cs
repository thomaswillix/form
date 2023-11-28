﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica1.manejadores;

namespace Practica1
{
    public partial class FrmEmpleados : Form
    {
        private Empleado e;
        private int a = 0;
        private DateTime d;

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
        }
        private void cargarEmpleados()
        {
            d = new DateTime(2002, 2, 3, 13, 0, 0);
            e = new Empleado(1,"Juan","Rodriguez","Perez", "programador",d);
            ControladorEmpleadosXML.listaEmpleados.Add(e);
            d = new DateTime(2000, 9, 4, 22, 0, 0);
            e = new Empleado(1, "Pablo", "Hernandez", "Ortiz", "becario", d);
            ControladorEmpleadosXML.listaEmpleados.Add(e);
            d = new DateTime(2005, 6, 2, 7, 0, 0);
            e = new Empleado(1, "Juana", "Martin", "Soler", "programador", d);
            ControladorEmpleadosXML.listaEmpleados.Add(e);
            d = new DateTime(1997, 8, 2, 12, 0, 0);
            e = new Empleado(1, "Maria", "Pinar", "Dueñas", "jefe", d);
            ControladorEmpleadosXML.listaEmpleados.Add(e);
        }

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
            foreach (Empleado e in ControladorEmpleadosXML.listaEmpleados)
            {
                crearChecked(e.Nombre ,posicion);
                posicion += 30;
            }
        }

        private void ordenarEmpleados(Func<Empleado, IComparable> aux)
        {
            ControladorEmpleadosXML.listaEmpleados = ControladorEmpleadosXML.listaEmpleados.OrderBy(aux).ToList();

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
                    int posicion = ControladorEmpleadosXML.listaEmpleados.FindIndex(x => x.Nombre == cd.Text);
                    ControladorEmpleadosXML.listaEmpleados.RemoveAt(posicion);
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

        }

        private void FrmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar los cambios?", "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ControladorEmpleadosXML.escribirEmpleadosXML();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No guardado");            
            }
        }
    }
}
