using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    // hvad skal vi kigge på??
    /* create a class 
     * create controller
     * finde ud af hvordan core virker (basics)
     * [annotations]
     * 
     * Hvis en pakke indeholder en masse ting, dvs hvis man kan klikke på den og se mere er det en metapakke
     * 
     * 
     * process
     * alle pakker mm skal installeres
     * class
     * migrate
     * controller
     * postman
     * 
     * ved Migraitons:
     * add-migration etnavn
     * update-database
     */

     /// <summary>
     /// 
     /// </summary>
    public class Student
    {
        public int studentId { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
    }
}
