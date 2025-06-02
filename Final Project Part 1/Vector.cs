using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

/// <summary>
/// Class <c>Vector</c> implements 3-dimensional vectors im C#. It overrides common operators to function as expected for Vectors with ~ acting as the velocity. 
///It also implements methods for normalizing vectors, dot products, cross prodcuts, getting the angle between two variables, and chaing the values of a vecotr to 
///absolute values. It also overrides the Equals Method and the ToString Method. 
/// Author:Rett Kinsey
/// Date:9/19/2023
/// </summary>
namespace HW4{

    public class Vector
    {

        private float _x;
        private float _y;
        private float _z;
        

        /// <summary>
        /// This is the empty constructor for the Vector Class.
        /// </summary>
        public Vector()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        /// <summary>
        /// This is the constructor for the Vector class with parameters.
        /// </summary>
        /// <param name="x">The x value of the vector.</param>
        /// <param name="y">The y value of the vector.</param>
        /// <param name="z">The z value of the vector.</param>
        public Vector(float x,float y,float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        
        public float X{
            get { return _x;}
            set{_x = value;}
        }
        
        public float Y{
            get { return _y;}
            set{_y = value;}
        }
        public float Z 
            {
            get { return _z;}
            set{_z = value;}
        }

        /// <summary>
        /// This overides the * operator to properly perfrom vector multiplication.
        /// </summary>
        /// <param name="k">The factor by which the vector is being multiplied. </param>
        /// <param name="v">The vector </param>
        /// <returns>The product vector</returns>
        public static Vector operator *(float k, Vector v)=>
            new Vector(k*v._x,k*v._y,k*v._z);

        /// <summary>
        /// This overides the * operator to properly perfrom vector multiplication.
        /// </summary>
        /// <param name="k">The factor by which the vector is being multiplied. </param>
        /// <param name="v">The vector </param>
        /// <returns>The product vector</returns>
        public static Vector operator *(Vector v, float k)=>
            new Vector(k*v._x,k*v._y,k*v._z);

        /// <summary>
        /// This overides the + operator to properly perfrom vector addition.
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector </param>
        /// <returns>The sum vector</returns>
        public static Vector operator +(Vector a, Vector b)=>
            new Vector(a._x+b._x,a._y+b._y,a._z+b._z);

        /// <summary>
        /// This overides the - operator to properly perfrom vector subtraction.
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector </param>
        /// <returns>The resultant vector</returns>
        public static Vector operator -(Vector a,Vector b)=>
            new Vector(a._x-b._x,a._y-b._y,a._z-b._z);
     
        /// <summary>
        /// This overides the - operator to negate vectors.
        /// </summary>
        /// <param name="v">The first vector. </param>
        /// <returns>The negated vector</returns>
        public static Vector operator -(Vector v)=>
            new Vector(-v._x,-v._y,-v._z);
        
        /// <summary>
        /// This overrides the + operator return the normal variable. 
        /// </summary>
        /// <param name="v">The first vector. </param>
        /// <returns>The same vector</returns>
        public static Vector operator +(Vector v)=>
          v;

         /// <summary>
        /// This overrides the ~ operator to return the length of the vector. 
        /// </summary>
        /// <param name="v">The  vector. </param>
        /// <returns>A float representing the length</returns>
        public static float operator ~(Vector v){
            return (float)(Math.Sqrt( Math.Pow(v._x,2) + Math.Pow(v._y,2) + Math.Pow(v._z,2)));
        }

        /// <summary>
        /// This performs cross products. 
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>A new vector perpendicular to the first 2</returns>
        /*
        public static Vector Cross(Vector a, Vector b){
            Vector myVector = new Vector(a._y*b._z - a._z*b._y, a._x*b._z - a._z*b._x , a._x*b._y - b._x*a._y );
            return myVector;
        }
        */
        public static Vector Cross(Vector a, Vector b){
            Vector myVector = new Vector(a._y*b._z - a._z*b._y,a._z*b._x - a._x*b._z , a._x*b._y - b._x*a._y );
            return myVector;
        }


        /// <summary>
        /// This performs dot products. 
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>the dot product</returns>
        public static float Dot(Vector a, Vector b){
            return a._x*b._x + a._y*b._y + a._z*b._z;
        }

        /// <summary>
        /// Makes all of the attributes of the vectors negative. 
        /// </summary>
        /// <param name="v">The vector. </param>
        /// <returns>An absolute vector</returns>
        public static void Abs( ref Vector v){
            v._x = Math.Abs(v._x);
            v._y = Math.Abs(v._y);
            v._z = Math.Abs(v._z);
            
        }

        /// <summary>
        /// Normalizes a vector
        /// </summary>
        /// <param name="vec">The vector. </param>
        /// <returns>the normalizes vector</returns>
        public static void Normalize( ref Vector v){
            float k = ~v;
            if (k != 0){
                float invK = 1/k;
                v._x = v._x*invK;
                v._y = v._y*invK;
                v._z = v._z*invK;
            }
        }

         /// <summary>
        /// Overrides ToString
        /// </summary>
        /// <returns>A string of the vector</returns>
        public override string ToString(){
            string myString = "(" +this._x +","+this._y+ ","+this._z + ")";
            return myString;
        }
        /// <summary>
        /// Overrides  the Equals method
        /// </summary>
        /// <param name="obj">The object being compared. </param>
        /// <returns>True if the obj is a vector with the same attribute values as the vector on which the method was called.</returns>
        public override bool Equals(object obj)
        {
            var b = obj as Vector;
            if (b == null)
                return false;
            if (this._x == b._x & this._y == b._y & this._z == b._z)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked{
            int hash = 17;
            hash = hash*23 + _x.GetHashCode();
            hash = hash*23 + _y.GetHashCode();
            hash = hash*23 + _z.GetHashCode();
            return hash;
            }
        }


        /// <summary>
        /// Gets the Angle between two vectors.
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>the normalizes vector</returns>
        public static double GetAngle(Vector a, Vector b){
            float dotProduct = Vector.Dot(a,b);
            float lenA = ~a;
            float lenB = ~b;

             return Math.Acos(dotProduct/(lenA*lenB));

        }

        /// <summary>
        /// Generates a random vector
        /// </summary>
        /// <returns>a random vector</returns>
        public static Vector RandomVector(){
            Random rdn = new Random();
           return new Vector((float)rdn.NextDouble(),(float)rdn.NextDouble(),(float)rdn.NextDouble());
        }

        /// <summary>
        /// Generates a random vector with vakues between min and max
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>the normalizes vector</returns>
        public static Vector RandomVector(float  min, float max){
            Random rdn = new Random();
            Vector randVec = new Vector();
            randVec.X = (float)rdn.NextDouble()*(max-min)+min;
            randVec.Y = (float)rdn.NextDouble()*(max-min)+min;
            randVec.Z = (float)rdn.NextDouble()*(max-min)+min;

             return randVec;

        }

        /// <summary>
        /// Generates a random vector with vakues between min and max
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>the normalizes vector</returns>
        public static Vector RandomInUnitSphere(){
            Vector search = new Vector();
            while (true){
                search = RandomVector(-1f,1f);
                if (Math.Pow(~search,2) < 1){
                    Vector.Normalize(ref search);
                    return search;
                }
            }

        }

        /// <summary>
        /// Checks whether a Vector is basically zero.
        /// </summary>
        /// <param name="a">The first vector. </param>
        /// <param name="b">The second vector. </param>
        /// <returns>the normalizes vector</returns>
        public static Boolean CloseToZero(Vector v){
            double bound = Math.Pow(10,-10);

            return v.X< bound &&-v.X < bound && v.Y<bound && -v.Y< bound && v.Z < bound && -v.Z< bound ;
                
            

        }


    }
}
