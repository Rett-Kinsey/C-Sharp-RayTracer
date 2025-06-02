

using System.ComponentModel;
using System.Drawing;

/// <summary>
/// Class <c>Plane</c> implements a plane shape
/// Author:Rett Kinsey
/// Date:11/2/2023
/// </summary>
namespace HW4{

     class Triangle: Shape {

        //private Vector _a;
        private Vector _v0;
        private Vector _v1;
        private Vector _v2;
        private Vector _n;

        private Vector _edge0;
        private Vector _edge1;
        private Vector _edge2;



        /// <summary>
        /// Creates a new generic
        ///  <c>Plane</c> centered at the origin. 
        /// </summary>
        public Triangle(){

            _v0 = new Vector(0,0,0);
            _v1 = new Vector(0,0,1);
            _v2 = new Vector(1,0,0);
            _n = new Vector(0,1,0);
            Centerpoint = _v0;
            //Centerpoint = (_v0+ _v1 + _v2)*(1/3);
            D = new Vector(255,100,100);
            A = new Vector(50,50,50);
            S = new Vector(255,255,255);
            Shiny = 100;

            _edge0 = _v1-_v0;
            _edge1 = _v2-_v1;
            _edge2 = _v0-_v2;
        }


        /// <summary>
        /// Creates a new <c>Plane</c> object with the specified parameters.
        /// </summary>
        /// <param name="a">A point in the plane</param>
        /// <param name="n">A normal to the plane</param>
        /// </summary>
        public Triangle(Vector v0, Vector v1,Vector v2){
            _v0 = v0;
            _v1 = v1;
            _v2 = v2;
           
            //Vector.Normalize(ref _n);
            Centerpoint = _v0;
            //Centerpoint = (_v0+ _v1 + _v2)*(1/3);
            D = new Vector(255,100,100);
            A = new Vector(50,50,50);
            S = new Vector(255,255,255);
            Shiny = 100;

            _edge0 = _v1-_v0;
            _edge1 = _v2-_v1;
            _edge2 = _v0-_v2;
            Vector edge2Inv = _v2 -_v0;

            //Vector.Normalize(ref _edge0);
            //Vector.Normalize(ref _edge1);
            //Vector.Normalize(ref _edge2);

            _n = Vector.Cross(_edge0,edge2Inv); //maybe adjust order of edged to adjust normals
            Vector.Normalize(ref _n);
            //Vector test = Vector.Cross(_v0,_v1);

            /* if (!_v0.Equals(new Vector(0,0,0)) && !_v1.Equals(new Vector(0,0,0))) {
                _n = Vector.Cross(_v0,_v1);
            }else if(_v0.Equals(new Vector(0,0,0))){
                 _n = Vector.Cross(_v1,_v2);
            }else {
                _n = Vector.Cross(_v2,_v0);
            }
            */
        }

        public Vector V0{
                get{ return _v0;}
                set{  _v0= value;}
            }

         public Vector V1{
                get{ return _v1;}
                set{  _v1= value;}
            }

         public Vector V2{
                get{ return _v2;}
                set{  _v2= value;}
            }

        public Vector N{
                get{ return _n;}
        }

        private void sortClockwise(){
            Vector btoa = _v0-_v1;
            Vector btoc = _v2-_v1;
            Vector det = Vector.Cross(btoa,btoc);


        }

        /// <summary>
        /// This finds the distance along a ray at which it intersects a shape. This returns positive infinity if there is no intersection.
        /// </summary>
        ///  <param name="r">The ray which may intersect a shape.</param>
        public override float Hit(Ray r){
            float denom = Vector.Dot(r.Direction,_n);
            if (denom == 0){
                return float.PositiveInfinity;
            }
            float t = Vector.Dot(_v0 - r.Origin,_n)/denom;


            if (t>0){
                if(InTriangle(t,r)){
                return t;
                }
            }
            return float.PositiveInfinity;

            
        }

        public bool InTriangle(float t,Ray r){
            Vector p = r.Origin + t*r.Direction;
            Vector c0 = p -_v0;
            Vector c1 = p -_v1;
            Vector c2 = p -_v2;

            if (p.X>.45&&p.X<.7 && p.Y<1 && p.Y>.7){
                int a = 12;
            }

            if (Vector.Dot(_n,Vector.Cross(_edge0,c0))> 0 &&
                Vector.Dot(_n,Vector.Cross(_edge1,c1))> 0 &&
                Vector.Dot(_n,Vector.Cross(_edge2,c2))> 0){
                    return true;
                }
            return false;

        }

         /// <summary>
        /// This finds the normal of a point on a shape
        /// </summary>
        ///  <param name="p">The point on a shape.</param>
        public override Vector Normal(Vector p){
            return _n;
        }
        

    }

}