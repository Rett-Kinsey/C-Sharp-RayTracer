/// <summary>
/// Class <c>Plane</c> implements a plane shape
/// Author:Rett Kinsey
/// Date:11/2/2023
/// </summary>


namespace HW4{

      class Plane: Shape {

        //private Vector _a;
        private Vector _ab;
        private Vector _n;

        /// <summary>
        /// Creates a new generic
        ///  <c>Plane</c> centered at the origin. 
        /// </summary>
        public Plane(){

            _ab = new Vector(0,0,0);
            _n = new Vector(0,1,0);
            Centerpoint = _ab;
            D = new Vector(255,100,100);
            A = new Vector(50,50,50);
            S = new Vector(255,255,255);
            Shiny = 100;
        }


        /// <summary>
        /// Creates a new <c>Plane</c> object with the specified parameters.
        /// </summary>
        /// <param name="a">A point in the plane</param>
        /// <param name="n">A normal to the plane</param>
        /// </summary>
        public Plane(Vector a, Vector n){
            _ab = a;//
            _n = n;
            Centerpoint = _ab;//
            D = new Vector(200,100,100);
            A = new Vector(50,50,50);
            S = new Vector(255,255,255);
            Shiny = 100.0f;
        }

        public Vector AB{
                get{ return _ab;}
                set{  _ab= value;}
            }

        public Vector N{
                get{ return _n;}
                set{  _n = value;}
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
            float hitPoint = Vector.Dot(_ab - r.Origin,_n)/denom;

           // if (hitPoint>0){
            //extremely jank work around for now.
            if (hitPoint>0){
                return hitPoint;
            }
            else{
                return float.PositiveInfinity;

            }
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