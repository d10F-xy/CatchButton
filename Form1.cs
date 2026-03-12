using System.Media;
using System.Drawing;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        // 7. 시각적 피드백(폼 제목 표시줄에 점수 출력)
        private int score = 0; // 점수 0으로 초기화
        // 놓친 횟수
        private int misses = 0;
        // 버튼의 초기 크기/위치 저장(재시작 시 복원)
        private Size initialButtonSize;
        private Point initialButtonLocation;
         
        public Form1()
        {
            InitializeComponent();
            // 초기 버튼 상태 저장
            initialButtonSize = Target.Size;
            initialButtonLocation = Target.Location;
            // 초기 폼 제목에 점수 표시
            this.Text = $"점수: {score}";
        }
        private void Target_MouseEnter(object sender, EventArgs e)
        {
            // 새로운 위치 값 세팅. 새로운 X, Y 좌표값
            //int x_position = 100;
            //int y_position = 150;

            // 버튼을 새로운 위치로 옮김 (새로운 Point 객체 생성)
            // Target.Location = new Point(x_position, y_position); 여기서 Target은 버튼 이름이니 버튼의 이름에 맞게 설정하면 됨

            // 1. 난수생성기준비 (Random.Shared 사용)
            var rd = System.Random.Shared;

            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            // ClientSize는 타이틀 바와 테두리를 제외한실제흰도화지영역임
            int maxX = this.ClientSize.Width - Target.Width; // 버튼의 가로길이만큼 빼줘야 버튼이 폼의 오른쪽 테두리를 넘지 않음
            int maxY = this.ClientSize.Height - Target.Height; // 버튼의 세로길이만큼 빼줘야 버튼이 폼의 아래쪽 테두리를 넘지 않음

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX = rd.Next(0, Math.Max(1, maxX));
            int nextY = rd.Next(0, Math.Max(1, maxY));

            // 4. 위치할당(새로운Point 객체생성)
            Target.Location = new Point((nextX), (nextY));

            // 5. 시각적 피드백(폼 제목 표시줄에 좌표 출력)
            // this.Text = $"버튼위치: ({nextX}, {nextY})"; // This는 현재 폼 객체 자신을 가리킴. Text는 폼 제목 표시줄에 출력되는 문자열을 의미

            // 6. 소리 재생 (버튼을 놓쳤을 때 피드백)
            SystemSounds.Beep.Play();

            // 7. 점수 감소 (놓칠 때 10점 감소)
            score -= 10;

            // 8. 놓친 횟수 증가 및 GameOver 체크
            misses++;
            if (misses >= 20)
            {
                GameOver();
                return; // GameOver 처리 후 더 이상 작업하지 않음
            }

            // 9. 폼 제목 갱신 (점수와 버튼 좌표)
            this.Text = $"점수: {score}  버튼위치: ({nextX}, {nextY})";


        }

        private void Target_Click(object sender, EventArgs e)
        {
            // 점수 추가 (잡을 때 100점 증가)
            score += 100; // 버튼을 잡았을 때 점수 100점 증가

            // 버튼 크기 10% 감소 (최소 크기 제한)
            int newWidth = (int)Math.Round(Target.Width * 0.9);
            int newHeight = (int)Math.Round(Target.Height * 0.9);
            Target.Size = new Size(newWidth, newHeight);

            // 버튼을 잡았을 때 다른 소리 재생
            SystemSounds.Asterisk.Play();

            // 폼 제목 갱신
            this.Text = $"점수: {score}  버튼위치: ({Target.Location.X}, {Target.Location.Y})";

            // 버튼을 잡았을 때 축하 메시지 박스 띄우기
            MessageBox.Show("축하합니다! 버튼을 잡았습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GameOver()
        {
            // 모든 버튼 비활성화
            foreach (Control c in this.Controls)
            {
                if (c is Button b)
                    b.Enabled = false;
            }

            // 재시작 요청 (Yes = 다시 시작, No = 종료(비활성 상태 유지))
            var result = MessageBox.Show("게임 오버! 20번 놓치셨습니다. 다시 시작하시겠습니까?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            // 점수와 놓친 횟수 초기화
            score = 0;
            misses = 0;

            // 버튼 크기/위치 복원
            Target.Size = initialButtonSize;
            Target.Location = initialButtonLocation;

            // 모든 버튼 재활성화
            foreach (Control c in this.Controls)
            {
                if (c is Button b)
                    b.Enabled = true;
            }

            // 폼 제목 갱신
            this.Text = $"점수: {score}";
        }
    }
}
