/// <summary>
/// Class <c>Ray</c> implemetns a class for modeling rays
/// Author:Rett Kinsey
/// Date:10/4/2023
/// </summary>


namespace HW4{

        public class Ray{

            private Vector _origin;
            private Vector _direction;

             /// <summary>
            /// This is the constructor for the Ray Class.
            /// 
            /// 
            /// </summary>
            public Ray(Vector origin, Vector direction){
                _origin = origin;
                _direction = direction;
                Vector.Normalize(ref _direction);
            }
 
        /// <summary>
        /// This is the Getter and Setter for the _origin variable.
        /// </summary>
            public Vector Origin{
                get{ return _origin;}
                set{_origin = value;}
            }

             /// <summary>
            /// This is the Getter and Setter for the _Direction variable.
            /// </summary>
            public Vector Direction{
                get{ return _direction;}
                set{  _direction = value;
                    Vector.Normalize(ref _direction);}
            }

            public Vector At(float t){
                return _origin + _direction*t;
            }

        }


}