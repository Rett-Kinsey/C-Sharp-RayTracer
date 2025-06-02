/// <summary>
/// Class <c>PlyReader</c> reads ply files and converts them into lists of triangles.
/// Author:Rett Kinsey
/// Date:11/2/2023
/// </summary>
/// 

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace HW4{

    public class Plyreader{

        private List<Vector> _vertices;

        private List<Shape> _faces;


        private int _vertexNum;
        private int _faceNum;

        public Plyreader(string fileName){

            using (var sr = new StreamReader(fileName)){

                string? line;
                string[] splitArray;
                int vsLeft = -1;
                int fsleft = -1;
                Vector vertex;
                _vertices = new List<Vector>();
                _faces = new List<Shape>();
                int triNum;

            while(( line = sr.ReadLine()) != null){

                if (line.Contains("element")){
                    splitArray = line.Split();
                    if (splitArray[1].Equals("vertex")){
                        _vertexNum = Int32.Parse(splitArray[2]);
                    }
                    if (splitArray[1].Equals("face")){
                        _faceNum = Int32.Parse(splitArray[2]);
                    }
                }
                

                if (vsLeft >0){
                    splitArray = line.Split();
                    vertex = new Vector(float.Parse(splitArray[0]),float.Parse(splitArray[1]),float.Parse(splitArray[2]));
                    _vertices.Add(vertex);
                }
                if (vsLeft == 0){
                    fsleft = _faceNum;
                }
                if (fsleft > 0){
                    splitArray = line.Split();
                    triNum =splitArray.Length-4;
                    for(int x = 0;x<triNum;x++){
                       Shape tri = new Triangle(_vertices[Int32.Parse(splitArray[1])],_vertices[Int32.Parse(splitArray[x+2])],_vertices[Int32.Parse(splitArray[x+3])]);
                       _faces.Add(tri);
                    }
                }
                

                if (vsLeft>-1){
                    vsLeft--;
                }
                if (fsleft>-1){
                    fsleft--;
                }
                if (line.Contains("end_header")){
                    vsLeft = _vertexNum;
                }
            }


            }

        }

        public List<Shape> Faces{
                get{ return _faces;}
                set{  _faces= value;}
            }



    }

}
