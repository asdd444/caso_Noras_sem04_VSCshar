using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace caso_Noras_sem04_VSCshar
{
    internal class Program
    {
        //funcion SIN RETORNO
        static public void titulo()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("\t\t UPN");
            Console.WriteLine("***********************");
        }
        //funcion CON RETORNO return 
        static public double validar_nota(string  mensaje)
        {
            //variable local
            double nota;
            while (true)

            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (double.TryParse(entrada, out nota) && nota>=0 && nota <= 20)
                        return nota;
                Console.WriteLine("error ; ingresar la nota entre {0-20}");

            }           
        }
        //METODO CON RETORNO
        static public double calcular_EF(double proy,double lab)
        {
            double nota_EF=proy*0.6 + lab * 0.4;
            return nota_EF;
        }
        //METODO CON RETORNO
        static public double Bono_cisco(double nota_EF, string tiene_cisco)
        {
            if(tiene_cisco == "s")
            {
                nota_EF += 1;
                if (nota_EF > 20)
                    nota_EF = 20;
            }
            return nota_EF;
        }
        //METODO CON RETORNO
        static public double prom_curso(double t1, double t2, double t3, double ep , double EF)
        {
            double promedio = t1 * 0.1 + t2 * 0.1 + t3 * 0.1 + ep * 0.2 + EF + 0.5;
            return promedio;
        }
        //METODO CON RETORNO
        static public string condicion(double promedio)
        {
            string estado;
            if (promedio >= 12)
                estado = "Aprobado";
            else
                estado = "Desaprobado";
            return estado;
        }
        static void Main(string[] args)
        {
            string curso_cisco;
            titulo();
            string nombre;
            Console.Write("ingresar nombre del estudiante:");
            nombre = Console.ReadLine();
            Console.WriteLine("ingreso de notas:");
            double t1 = validar_nota("ingresar la nota t1:");
            double t2 = validar_nota("ingresar la nota t2:");
            double t3 = validar_nota("ingresar la nota t3:");
            double ep = validar_nota("ingreasr nota del examen parcial:");
            Console.WriteLine("ingreasr notas para el examen final:");
            double proy_final = validar_nota("ingresar nota de proyecto(60%):");
            double n_lab = validar_nota("ingresar nota de laboratorio(40%):");
            while(true)
            {
                Console.Write("realizo el curso de cisco {s/n] ");
                curso_cisco = Console.ReadLine();
                if (curso_cisco == "S" || curso_cisco == "n")
                    break;
                Console.WriteLine("error , ingresar unicamente {s/n}");

            }
            double nota_EF = calcular_EF(proy_final, n_lab);
            double nota_EF_cisco = Bono_cisco(nota_EF, curso_cisco);
            double promedio = prom_curso(t1, t2, t3, ep, nota_EF_cisco);
            string cond_est = condicion(promedio);





            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine("REPORTE DE NOTAS: " + nombre);
            Console.WriteLine("++++++++++++++++++++++++++");
            if (curso_cisco == "s")
                Console.WriteLine("felicitaciones por llevar el curso de cisco");
            Console.WriteLine("nota examen final: " + nota_EF_cisco);
            Console.WriteLine("nota de curso:2 " + promedio);
            Console.WriteLine("condicion : " + cond_est);
            Console.WriteLine("+++++++++++++++++++++++++++++");
            Console.ReadKey();
             
           
        }
    }
}
