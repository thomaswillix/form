﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Practica1
{
    public partial class FrmProyectos : Form
    {
        Proyecto p;
        DateTime fechaIni;
        DateTime fechaFin;

        public FrmProyectos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cargarProyectos()
        {
            fechaIni = new DateTime(2021, 2, 3 , 13, 0, 0);
            fechaFin = DateTime.Today;
            p = new Proyecto("Hunter X Hunter", fechaIni, fechaFin);
            Proyecto.listaProyectos.Add(p);
            fechaIni = new DateTime(2022, 5, 21, 8, 0, 0);
            fechaFin = new DateTime(2023, 9, 30, 9, 0, 0);
            p = new Proyecto("One Piece", fechaIni, fechaFin);
            Proyecto.listaProyectos.Add(p);
            fechaIni = new DateTime(2020, 7, 14, 6, 0, 0);
            fechaFin = new DateTime(2020, 10, 3, 10, 0, 0);
            p = new Proyecto("Death Note", fechaIni, fechaFin);
            Proyecto.listaProyectos.Add(p);
            fechaIni = new DateTime(2023, 9, 21, 19, 0, 0);
            fechaFin = DateTime.Today;
            p = new Proyecto("Steins Gate", fechaIni, fechaFin);
            Proyecto.listaProyectos.Add(p);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private void mostrarProyectos()
        {
            groupBox1.Controls.Clear();
            int n = 1;
            int posicion = 10;
            foreach (Proyecto project in Proyecto.listaProyectos)
            {
                crearCheckedLB(project.Descripcion, posicion, n);
                posicion += 30;
                n++;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ordenarProyectosFecha();
        }
        
        private void ordenarProyectosFecha()
        {
            groupBox1.Controls.Clear();
            Proyecto.listaProyectos.Sort();
            mostrarProyectos();
        }
        private void crearCheckedLB(string proyectoText, int posicion, int contadorNombre)
        {
            CheckedListBox clb = new System.Windows.Forms.CheckedListBox();
            clb.Text = proyectoText + "\n";
            clb.AutoSize = true;
            clb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
            ((byte)(0)));
            clb.Location = new System.Drawing.Point(75, posicion);
            clb.Name = "lblProyecto" + contadorNombre;
            clb.Size = new System.Drawing.Size(291, 20);
            clb.TabIndex = 1;
            groupBox1.Controls.Add(clb);
        }

        private void FrmProyectos_Load(object sender, EventArgs e)
        {
            cargarProyectos();
            mostrarProyectos();
        }
        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to really exit ? ",
                                    "Exit",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                this.Show();
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void ordenarNombre_Click(object sender, EventArgs e)
        {
            ordenarProyectosNombre(Proyecto => Proyecto.Descripcion);
            groupBox1.Controls.Clear();
            mostrarProyectos();
        }

        
        private void ordenarProyectosNombre(Func<Proyecto,IComparable> aux)
        {
            Proyecto.listaProyectos = Proyecto.listaProyectos.OrderBy(aux).ToList();
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
