namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Target_MouseEnter(object sender, EventArgs e)
        {
            // 새로운 위치 값 세팅. 새로운 X, Y 좌표값
            int x_position = 100;
            int y_position = 150;

            // 버튼을 새로운 위치로 옮김 (새로운 Point 객체 생성)
            Target.Location = new Point(x_position, y_position); 여기서 Target은 버튼 이름이니 버튼의 이름에 맞게 설정하면 됨

           

        private void Target_Click(object sender, EventArgs e)
        {

        }
    }
}
