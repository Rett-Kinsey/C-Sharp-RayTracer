/// <summary>
/// Class <c>Sphere</c> implements a sphere shape.
/// Author:Rett Kinsey
/// Date:11/2/2023
/// </summary>


namespace HW4{

    class Sphere: Shape{

        private Vector _center;
        private float _radius;

        /// <summary>
        /// Creates a new generic
        ///  <c>sphere</c> centered at the origin. 
        /// </summary>
        public Sphere(){

            _center = new Vector(0,0,0);
            _radius = 1;
            Centerpoint = _center;
            D = new Vector(255,255,255);
            A = new Vector(20,20,20);
            S = new Vector(255,255,255);
            Shiny = 100.0f;
        }

        /// <summary>
        /// Creates a new <c>Sphere</c> object with the specified parameters.
        /// </summary>
        /// <param name="center">The center of the shape</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// </summary>
        public Sphere(Vector center, float radius){
            _center = center;
            _radius = radius;
            Centerpoint = _center;
            D = new Vector(255,255,255);
             A = new Vector(50,50,50);
            S = new Vector(255,255,255);
            Shiny = 100.0f;
        }

        public Vector Center{
                get{ return _center;}
                set{  _center = value;}
            }

        public float Radius{
                get{ return _radius;}
                set{  _radius = value;}
        }

        /// <summary>
        /// This finds the distance along a ray at which it intersects a shape. This returns positive infinity if there is no intersection.
        /// </summary>
        ///  <param name="r">The ray which may intersect a shape.</param>
        public override float Hit(Ray r){
            float discriminant  =  (float)(Math.Pow(Vector.Dot(r.Direction,r.Origin-_center),2) - 
            Vector.Dot(r.Direction,r.Direction)*
            (Vector.Dot(r.Origin-_center,r.Origin-_center) - Math.Pow(_radius,2)));
            float positiveBranch;
            float negativeBranch;
            if (discriminant < 0){
                return float.PositiveInfinity;
            }else{
                positiveBranch = (Vector.Dot(-r.Direction,r.Origin-_center)+ (float)Math.Sqrt(discriminant))/Vector.Dot(r.Direction,r.Direction);
                negativeBranch = (Vector.Dot(-r.Direction,r.Origin-_center)- (float)Math.Sqrt(discriminant))/Vector.Dot(r.Direction,r.Direction);
                if (positiveBranch > negativeBranch && negativeBranch > 0){
                    //WriteLine("negative Branch : " + negativeBranch);
                    return negativeBranch;
                }  if (positiveBranch > 0){
                    return positiveBranch;
                }else{
                    return float.PositiveInfinity;
                }
            }
        }

         /// <summary>
        /// This finds the normal of a point on a shape
        /// </summary>
        ///  <param name="p">The point on a shape.</param>
        public override Vector Normal(Vector p){
            
            
            Vector outwards = p-_center;
            Vector.Normalize(ref outwards);
            return outwards;
        }



    }

}