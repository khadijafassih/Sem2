using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge1
{
    internal class Student
    {
        public Student(string name, float matricMarks, float fscMarks, float ecatMarks)
        {
            Name = name;
            MatricMarks = matricMarks;
            FscMarks = fscMarks;
            EcatMarks = ecatMarks;
        }
        public string Name;
        public float MatricMarks;
        public float FscMarks;
        public float EcatMarks;
        public float Aggregate;
       
    }
  }
