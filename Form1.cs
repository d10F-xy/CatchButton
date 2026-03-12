using System.Media;

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
            //int x_position = 100;
            //int y_position = 150;

            // 버튼을 새로운 위치로 옮김 (새로운 Point 객체 생성)
            // Target.Location = new Point(x_position, y_position); 여기서 Target은 버튼 이름이니 버튼의 이름에 맞게 설정하면 됨

            // 1. 난수생성기준비
            Random rd = new Random();

            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            // ClientSize는 타이틀 바와 테두리를 제외한실제흰도화지영역임
            int maxX = this.ClientSize.Width - Target.Width; // 버튼의 가로길이만큼 빼줘야 버튼이 폼의 오른쪽 테두리를 넘지 않음
            int maxY = this.ClientSize.Height - Target.Height; // 버튼의 세로길이만큼 빼줘야 버튼이 폼의 아래쪽 테두리를 넘지 않음

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX = rd.Next(0, maxX);
            int nextY = rd.Next(0, maxY);

            // 4. 위치할당(새로운Point 객체생성)
            Target.Location = new Point((nextX), (nextY));

            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})"; // This는 현재 폼 객체 자신을 가리킴. Text는 폼 제목 표시줄에 출력되는 문자열을 의미

            // 6. 소리 재생 (버튼을 놓쳤을 때 피드백)
            SystemSounds.Beep.Play();
        }

        private void Target_Click(object sender, EventArgs e)
        {
            // 버튼을 잡았을 때 다른 소리 재생
            SystemSounds.Asterisk.Play();

            // 버튼을 잡았을 때 축하한다는 메시지 박스 띄우기
            MessageBox.Show("축하합니다! 버튼을 잡았습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
