/// <summary>
/// Class <c>Ray</c> Creates a camera
/// Author:Rett Kinsey
/// Date:10/4/2023
/// </summary>


using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.XPath;

namespace HW4{

    class Camera{

        public enum Projection{
            Perspective,
            Orthographic
        }

        private Projection _projection;
        private Vector _eye;
        private Vector _lookAt;
        private Vector _up;
        private float _near;
        private float _far;
        private int _width;
        private int _height;
        private float _left;
        private float _right;
        private float _bottom;
        private float _top;
        private Vector _w;
        private Vector _u;
        private Vector _v;

        private int _recurLimit;

        /// <summary>
        /// Creates a new generic
        /// orthographic <c>Camera</c> centered at the origin. The generated image
        /// plane is 512 x 512 pixels and the viewing frustum is 2 x 2 units.
        /// </summary>
        public Camera(){
            _projection = Projection.Orthographic;
            _eye = new Vector(0,0,0);
            _lookAt = new Vector (0,0,1);
            _up = new Vector(0,1,0);
            _width = 512;
            _height = 512;
            _near = (float).1;
            _far = 10;
            _left = -1;
            _right = 1;
            _bottom = -1;
            _top = 1;
            _recurLimit = 2;
            CreateOrthormalBasis();

        }

        /// <summary>
        /// Creates a new <c>Camera</c> object with the specified parameters.
        /// </summary>
        /// <param name="projection">The projection type for the camera(e.g., Perspective, Orthographic).</param>
        /// <param name="eye">The position of the camera’s eye point in world coordinates.</param>
        /// <param name="lookAt">The location the camera is looking at in world coordinates.</param>
        /// <param name="up">The camera’s up vector.</param>
        /// <param name="near">The distance from the camera’s eye point to the near clipping plane.(default (.1). </param>
        /// <param name="far">The distance from the camera’s eye point to the far clipping plane.(default: 10).</param>
        /// <param name="width">The width of the camera’s viewport in pixels (default: 512).</param>
        /// <param name="height">The height of the camera’s viewport in pixels (default: 512).</param>
        /// <param name="left">The left boundary of the camera’s viewing frustum (default: -1.0).</param>
        /// <param name="right">The right boundary of the camera’s viewing frustum (default: 1.0).</param>
        /// <param name="bottom">The bottom boundary of the camera’s viewing frustum (default: -1.0).</param>
        /// <param name="top">The top boundary of the camera’s viewing frustum (default: 1.0).</param>
        /// </summary>

        public Camera( Projection projection, Vector eye,Vector lookAt, Vector up,
         float near =(float).1, float far =10, int width = 512, int height = 512 ,
         float left = -1, float right = 1, float bottom = -1, float top = 1, int recurLimit  =2)
        {
            _projection = projection;

            _eye = eye;
            _lookAt = lookAt;
            _up = up;
            _near = near;
            _far = far;
            _width = width;
            _height = height;
            _left = left;
            _right = right;
            _bottom = bottom;
            _top = top; 
            _recurLimit = recurLimit;
            CreateOrthormalBasis();
        }


         /// <summary>
        /// This is the Getter and Setter for the _eye variable.
        /// </summary>
        public Vector Eye{
            get { return _eye;}
            set {_eye = value;}
        }

         /// <summary>
        /// This is the Getter and Setter for the _lookAt variable.
        /// </summary>
        public Vector LookAt{
            get { return _lookAt;}
            set {_lookAt = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _up variable.
        /// </summary>
        public Vector Up{
            get { return _up;}
            set {_up = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _near variable.
        /// </summary>
        public float Near{
            get { return _near;}
            set {_near = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _far variable.
        /// </summary>
        public float Far{
            get { return _far;}
            set {_far = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _width variable.
        /// </summary>
        public int Width{
            get { return _width;}
            set {_width = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _height variable.
        /// </summary>
        public int Height{
            get { return _height;}
            set {_height = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _left variable.
        /// </summary>
        public float Left{
            get { return _left;}
            set {_left = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _right variable.
        /// </summary>
        public float Right{
            get { return _right;}
            set {_right = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _bottom variable.
        /// </summary>
        public float Bottom{
            get { return _bottom;}
            set {_bottom = value;}
        }

        /// <summary>
        /// This is the Getter and Setter for the _top variable.
        /// </summary>
        public float Top{
            get { return _top;}
            set {_top = value;}
        }

         /// <summary>
        /// This is the Getter and Setter for the RecurLimit variable.
        /// </summary>
        public int RecurLimit{
            get { return _recurLimit;}
            set {_recurLimit = value;}
        }

        /// <summary>
        /// This defines an orthonormal basis and sets _w,_u, and _v.
        /// </summary>
        public void CreateOrthormalBasis()
        {
            _w = _eye - _lookAt;
            //_w = _lookAt - _eye;
            _u = Vector.Cross(_up,_w);
            _v = Vector.Cross(_w,_u);
            //_v.Y = -_v.Y;
            Vector.Normalize(ref _w);
            Vector.Normalize( ref _u);
            Vector.Normalize(ref _v);
            
        }

        /// <summary>
        /// This converts the pixel count coordinates to a U_v basis. 
        /// </summary>
        ///  <param name="i">The horizontal pixel. </param>
        ///  <param name="j">The vertical pixel. </param>
        ///  <param name="u">The u value to be altered. </param>
        ///  <param name="v">The v value to be altered. </param>

        public void ScreenCoords(int i, int j, ref float u, ref float v){

            float UGap = (_right-_left)/_width;
            float VGap = (_top-_bottom)/_height;
            //float UGap = (float)i/_width;
            //float VGap = (float)j/_height;
            Random rdn = new Random();
            float USamp=((float)rdn.NextDouble()*(.5f-(-.5f))-.5f)*UGap;
            float VSamp=((float)rdn.NextDouble()*(.5f-(-.5f))-.5f)*VGap;
            float variance = (float)rdn.NextDouble();
            u = _left +(_right-_left)*i/_width + USamp;
            v = _bottom +(_top-_bottom)*j/_height + VSamp;

        }

        /// <summary>
        /// This creates a ray which passes through a specific pixel. 
        /// </summary>
        ///  <param name="i">The horizontal pixel. </param>
        ///  <param name="j">The vertical pixel. </param>
        public Ray MakeCameraRay(int i, int j){
            float u = 0;
            float v = 0;
            Ray screenRay;
            ScreenCoords(i,j,ref u, ref v);

             if (_projection == Projection.Orthographic)
            {

                Vector origin = _eye + u*_u+ v*_v;
                screenRay = new Ray(origin, -_w);
                return screenRay;
            } else {

                Vector direction = u*_u+ v*_v -_w;
                screenRay = new Ray(_eye, direction);
                return screenRay;
                
            }
        }

        /// <summary>
        /// This method finds where  a cameraRays intersects shapes in a scene. 
        /// </summary>
        ///  <param name="r"> the ray which is projected by the camera </param>
        ///  <param name="world">The scene being drawn </param>
        ///  <param name="ref tester">A ref variable for image to be colored </param>
        ///  <param name="i"> the i of the pixel to be colored </param>
        ///  <param name="j"> the j of the pixel to be colored </param>
        private Vector ShapesIntersect(Ray r,Scene world,int i, int j, ref Image tester,ref float[,] depthChart){ //ref float[,] depthChart
            List<Shape> gameShapes = world.AllShapes;
            float t;
            Vector shapeColor = new Vector(0,0,0);
            depthChart[i,j] = float.PositiveInfinity;

            // Can be spruced up to not call shapecolor and test paint for every smaller hit/
            foreach (var gameShape in gameShapes)
            {
                t = gameShape.Hit(r);
                if (t <=_far && t>_near){
                    if (depthChart[i,j] > t){
                        depthChart[i,j] = t;
                            shapeColor = GetColor(gameShape,world.Light,t,r,world,_recurLimit);
                            //tester.Paint(i,j,shapeColor*((_far-t)/_far));
                        
                    }
                }
    
            }
            return shapeColor;
        }

        private Vector SecondaryHitColor(Ray r, Scene world,Shape currShape,Vector lightSource,int recurLevel){
            //could use sceondary depthChart
            List<Shape> gameShapes = world.AllShapes;
            float depth = float.PositiveInfinity;
            float t;
            Vector color = new Vector(0,0,0);

             foreach (var gameShape in gameShapes)
            {
                if (!gameShape.Equals(currShape)){ // won't work for more complex shapes
                    t = gameShape.Hit(r);
                    

                    if (depth>t){
                        depth = t;
                        color = GetColor(gameShape,lightSource,depth,r,world,recurLevel);
                }      
            }
            }
            return color;
        }

        private float SecondaryHitShadow(Ray r, Scene world,Shape currShape){
            //could use sceondary depthChart
            List<Shape> gameShapes = world.AllShapes;
            float t = float.PositiveInfinity;

             foreach (var gameShape in gameShapes)
            {
                if (!gameShape.Equals(currShape)){ // won't work for more complex shapes
                    t = gameShape.Hit(r);
                //if (t <=_far && t>_near){ may eventually make this the distance between the point and the lightsource though that might go on result.
                 // actally do in getcolor   
                    if (!float.IsInfinity(t))
                        {
                        return t;
                        }
                //}
            }
            }
            return t;

        }
        private Vector GetColor(Shape shape, Vector lightSource, float t, Ray r,Scene world,int recurLevel){

            if (recurLevel <= 0){
                return new Vector(0,0,0);
            }

            Vector p = r.At(t);
            Vector l = lightSource- p;

            //shadow checking 
            Ray shadow = new Ray(p,l);
            float f = SecondaryHitShadow(shadow,world,shape);
            if (!float.IsInfinity(f)){
               return new Vector(30,30,30);
            }


            Vector ambient = shape.A;

           
            
            Vector.Normalize(ref l);

            Vector n = shape.Normal(p);

            Vector diffuse = shape.D*Math.Max(0,Vector.Dot(l,n));
            diffuse.X = shape.Clamp(0,255,diffuse.X);
            diffuse.Y = shape.Clamp(0,255,diffuse.Y);
            diffuse.Z = shape.Clamp(0,255,diffuse.Z);

            Vector v = _eye - p;
            Vector.Normalize(ref v);

            Vector h = v+l;
            Vector.Normalize(ref h);

            Vector specular = shape.S*(float)Math.Pow(Math.Max(0,Vector.Dot(h,n)),shape.Shiny);
            specular.X = shape.Clamp(0,255,specular.X);
            specular.Y = shape.Clamp(0,255,specular.Y);
            specular.Z = shape.Clamp(0,255,specular.Z);

            Vector finalColor = ambient + diffuse + specular;
            finalColor.X = shape.Clamp(0,255,finalColor.X);
            finalColor.Y = shape.Clamp(0,255,finalColor.Y);
            finalColor.Z = shape.Clamp(0,255,finalColor.Z);

            // reflection // call with recur limit - 1;

            Ray scatter = new Ray(p,shape.Normal(p)+ Vector.RandomInUnitSphere());
            if (Vector.CloseToZero(scatter.Direction)){
                scatter.Direction = shape.Normal(p);
            }
            finalColor = finalColor*.8f + (.2f*SecondaryHitColor(scatter,world,shape,lightSource,recurLevel-1));
            //.2 is placeholder for albedo/refelctiveness
            return finalColor;

        }
        private void PopulateBufferInfinite(ref float[,] depthChart){

             for (int i = 0; i < _width; i++)
                 {
                    for (int j = 0; j < _height; j++)
                    {
                        depthChart[i,j] = float.PositiveInfinity;
                        
                    }
                 }

        }


        /// <summary>
        /// This renders an image based on the selected scene.
        /// </summary>
        ///  <param name="name">The name under which the created image is to be saved. </param>
        ///  <param name="scene">The scene to draw. </param>
        public void RenderImage(String name,Scene world,int sampleNum)
        {
            Image tester = new Image(_width,_height);
            Ray currRay;
            //float t;
            float[,] depthChart = new float[_width,_height];
            Vector shapeColor;

            PopulateBufferInfinite(ref depthChart);
             Vector testVector = new Vector(0,0,0);
           
            if (_projection == Projection.Orthographic)
            {
                
                 for (int i = 0; i < _width; i++)
                 {
                    for (int j = 0; j < _height; j++)
                    {
                       
                        shapeColor = new Vector(0,0,0); // might be quicker to make function whihc sets all to 0 then reinsatniating
                        for (int sample = 0; sample < sampleNum;sample++){
                            currRay = MakeCameraRay(i,j);

                            shapeColor = shapeColor + ShapesIntersect(currRay,world,i,j,ref tester,ref depthChart);

                            if (!shapeColor.Equals(testVector)){
                                int q = 0;
                            }
                        }
                        float sampleDivisor = 1f/sampleNum;
                        shapeColor = shapeColor * sampleDivisor;
                    
                        if (!shapeColor.Equals(testVector)){
                                  float t = depthChart[i,j];
                            }
                      
                        tester.Paint(i,j,shapeColor*((_far-depthChart[i,j])/_far));
                    }
                 }

                 tester.SaveImage(name);
            }else
            {
                 for (int i = 0; i < _width; i++)
                 {
                    for (int j = 0; j < _height; j++)
                    {
                        shapeColor = new Vector(0,0,0); // might be quicker to make function whihc sets all to 0 then reinsatniating
                        for (int sample = 0; sample < sampleNum;sample++){
                            currRay = MakeCameraRay(i,j);
                            
                            shapeColor = shapeColor + ShapesIntersect(currRay,world,i,j,ref tester,ref depthChart);
                        }
                        float sampleDivisor = 1f/sampleNum;
                        shapeColor = shapeColor * sampleDivisor;
                        
                        tester.Paint(i,j,shapeColor*((_far-depthChart[i,j])/_far));
                        
                    }
                 }

                 tester.SaveImage(name);
            }
        }
    }



 }


