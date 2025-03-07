# Unity Project: VIVALDI Exhibition
Welcome to **VIVALDI Exhibition**! 이 유니티 프로젝트는 메타버즈 개발팀 사이드 VR 프로젝트 입니다.   


## 📁 Project Structure
📂 VIVALDI Exhibition   
┣ 📂 Assets  
┃ ┣ 📂 AK Studio Art   
┃ ┃ ┣ 📂 Art Gallery Vol.9   
┃ ┃ ┃ ┗ 📂 Scenes   
┃ ┃ ┃ ┃ ┗ 🎬 Main.unity   # 메인씬   
┃ ┣ 📂 MiniGames   
┃ ┃ ┣ 📂 Spring   # 봄 미니게임 씬   
┃ ┃ ┣ 📂 Summer   # 여름 미니게임 씬   
┃ ┃ ┣ 📂 Autumn   # 가을 미니게임 씬   
┃ ┃ ┗ 📂 Winter   # 겨울 미니게임 씬   
┃ ┣ 📂 Scripts   
┃ ┃ ┣ 📜 AudioManager.cs # 장소에 따라 오디오 조절    
┃ ┃ ┣ 📜 AutumnGameManager.cs # 가을 게임 컨트롤러    
┃ ┃ ┣ 📜 BugNet.cs # 잠자리채 트리거 기능    
┃ ┃ ┣ 📜 Butterfly.cs # 나비 움직임 기능     
┃ ┃ ┣ 📜 FadeScreen.cs # 공간 이동 시 카메라에 페이드 아웃 효과   
┃ ┃ ┣ 📜 GameManager.cs # 씬 교체 시 오브젝트 파괴 여부 조절   
┃ ┃ ┣ 📜 HarvestSpot.cs # 가을 미니게임 밭   
┃ ┃ ┣ 📜 Hoe.cs # 가을 미니게임 밭   
┃ ┃ ┣ 📜 HoverFrame.cs # 액자 아웃라인 효과 on/off   
┃ ┃ ┣ 📜 MiniGame.cs # 계절 별 미니 게임 진행 조절(계절 공통)   
┃ ┃ ┣ 📜 PlaceTransitionManager.cs # 씬 이동 시 플레이어 위치 및 카메라 설정   
┃ ┃ ┣ 📜 SceneTransitionManager.cs # 활성화 된 계절 씬 로드   
┃ ┃ ┣ 📜 SnowBall.cs # 겨울 미니게임 눈덩이 트리거 기능   
┃ ┃ ┣ 📜 SummerGameManager.cs # 여름 미니게임 컨트롤러   
┃ ┃ ┣ 📜 ThemeManager.cs # 활성화 된 계절에 따른 명화 배치 및 설명 활성화    
┃ ┃ ┣ 📜 WinterGameManager.cs # 겨울 미니게임 스코어 계산    
┃ ┃ ┗ 📜 ZoneEntrance.cs # 오브젝트 거리에 따라 상호작용 UI on/off 조절   
┃ ┗ 📂 Scenes   
┃ ┃ ┗ 📂 VivaldiScenes   # 계절 별 명화 씬


## 🎮 How To Play
1. 액자와 상호작용하여 계절 선택.
<img src="https://github.com/user-attachments/assets/926d70dc-3db5-469a-8eb3-0bd11fcd179b" width="732" height="386"/>   

2. 미디어 아트관, 명화관, 미니게임관 선택하여 진입
<img src="https://github.com/user-attachments/assets/2cd95a80-3276-4885-bdb1-606435380efe" width="732" height="386"/>   

3. 미디어 아트관 / 명화관 스크린샷
<img src="https://github.com/user-attachments/assets/5573ebf5-19c3-4ba7-8bdd-46d6fe579c0a" width="360" height="180"/>
<img src="https://github.com/user-attachments/assets/e6ea0ccd-6f5a-4bec-9f45-750e526c2cd0" width="360" height="180"/>   

4. 미니게임
<img src="https://github.com/user-attachments/assets/81911cd2-fb19-4132-a7e8-46c45b4251f9" width="360" height="180"/>
<img src="https://github.com/user-attachments/assets/09dc9423-4f70-4f01-9a4b-5cd7292fa43e" width="360" height="180"/>
<img src="https://github.com/user-attachments/assets/d141204b-8ff9-433d-a59d-643e74591a76" width="360" height="180"/>
<img src="https://github.com/user-attachments/assets/b712267c-fd9f-497a-a8b2-99a7e6e4b3e4" width="360" height="180"/>


## 🛠️ Dependencies
- Unity **2022.3.17 LTS** or later
