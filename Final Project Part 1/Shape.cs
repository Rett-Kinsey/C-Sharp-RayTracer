/// <summary>
/// Class <c>Shape</c> implements an abstract class which to model shapes
/// Author:Rett Kinsey
/// Date:11/2/2023
/// </summary>




namespace HW4{

     public abstract class Shape{

        private Vector _centerpoint;
        private Vector _diffuseColor;
        private Vector _ambientColor;
        private Vector _specularColor;
        private float _shininess;

        /// <summary>
        /// This is the Getter and Setter for the _centerPoint variable.
        /// </summary>
        public Vector Centerpoint{
                get{ return _centerpoint;}
                set{  _centerpoint= value;}
            }

        /// <summary>
        /// This is the Getter and Setter for the _diffuseColor variable.
        /// </summary>
        public Vector D{
                get{ return _diffuseColor;}
                set{  _diffuseColor = value;}
            }

        /// <summary>
        /// This is the Getter and Setter for the _ambientColor variable.
        /// </summary>
        public Vector A{
                get{ return _ambientColor;}
                set{  _ambientColor = value;}
            }

        /// <summary>
        /// This is the Getter and Setter for the _specularColor variable.
        /// </summary>
        public Vector S{
                get{ return _specularColor;}
                set{ _specularColor = value;}
            }

        /// <summary>
        /// This is the Getter and Setter for the _shininess variable.
        /// </summary>
        public float Shiny{
                get{ return _shininess;}
                set{ _shininess = Clamp(1f,128f,value);}
            }


        public float Clamp(float min, float max, float val){
            
            if (val < min){
                return min;
            } else if (val > max){
                return max;
            } else{
                return val;
            }
        }

         /// <summary>
        /// This finds the distance along a ray at which it intersects a shape. This returns positive infinity if there is no intersection.
        /// </summary>
        ///  <param name="r">The ray which may intersect a shape.</param>
        public abstract float Hit(Ray r);

        /// <summary>
        /// This finds the normal of a point on a shape
        /// </summary>
        ///  <param name="p">The point on a shape.</param>
        public abstract Vector Normal(Vector p);
        

    }

}