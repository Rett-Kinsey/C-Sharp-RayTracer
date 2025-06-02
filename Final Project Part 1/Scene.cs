/// <summary>
/// Class <c>Scene</c> creates an environment in which shapes are stored. 
/// Author:Rett Kinsey
/// Date:10/4/2023
/// </summary>




namespace HW4{

    class Scene{

        private List<Shape> _allShapes;
        private Vector _light;

        //constructor
        public Scene(){
                _allShapes = new List<Shape>();
                _light =new Vector (0,10,0);
            }

        //constructor
        public Scene(List<Shape> allShapes){
                _allShapes = AllShapes;
                _light = new Vector(0,10,0);
            }

        //getter
        public List<Shape> AllShapes{
                get{ return _allShapes;}
            }

        public Vector Light{
                get{ return _light;}
                set{ _light = value;}
            }

        public void AddShape(ref Shape figure){
            _allShapes.Add(figure);

        }

    }

}