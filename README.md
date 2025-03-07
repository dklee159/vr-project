# Unity Project: VIVALDI Exhibition
Welcome to **VIVALDI Exhibition**! 이 유니티 프로젝트는 메타버즈 개발팀 사이드 VR 프로젝트 입니다.   

## 📣 Introduce
- 게이밍 요소보다는 체험 요소 강조
- 주로 정적일 수 밖에 없는 미술관에 미디어 아트를 통해 공감각적로 요소 활용 (VR 장점 부각)
- 각 계절에 맞는 미니게임(체험) 요소 삽입
  - 봄 : 화분에 꽃 키우기
  - 여름 : 날아다니는 나비 채집
  - 가을 : 밭에서 채소 수확
  - 겨울 : 눈덩이로 눈사람 맞추기

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
┃ ┃ ┣ 📜 [AudioManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/AudioManager.cs "") # 장소에 따라 오디오 조절    
┃ ┃ ┣ 📜 [AutumnGameManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/AutumnGameManager.cs "") # 가을 게임 컨트롤러    
┃ ┃ ┣ 📜 [BugNet.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/BugNet.cs "") # 잠자리채 트리거 기능    
┃ ┃ ┣ 📜 [Butterfly.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/Butterfly.cs "") # 나비 움직임 기능     
┃ ┃ ┣ 📜 [FadeScreen.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/FadeScreen.cs "") # 공간 이동 시 카메라에 페이드 아웃 효과   
┃ ┃ ┣ 📜 [GameManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/GameManager.cs "") # 씬 교체 시 오브젝트 파괴 여부 조절   
┃ ┃ ┣ 📜 [HarvestSpot.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/HarvestSpot.cs "") # 가을 미니게임 밭   
┃ ┃ ┣ 📜 [Hoe.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/Hoe.cs "") # 가을 미니게임 밭   
┃ ┃ ┣ 📜 [HoverFrame.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/HoverFrame.cs "") # 액자 아웃라인 효과 on/off   
┃ ┃ ┣ 📜 [MiniGame.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/MiniGame.cs "") # 계절 별 미니 게임 진행 조절(계절 공통)   
┃ ┃ ┣ 📜 [PlaceTransitionManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/PlaceTransitionManager.cs "") # 씬 이동 시 플레이어 위치 및 카메라 설정   
┃ ┃ ┣ 📜 [SceneTransitionManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/SceneTransitionManager.cs "") # 활성화 된 계절 씬 로드   
┃ ┃ ┣ 📜 [SnowBall.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/SnowBall.cs "") # 겨울 미니게임 눈덩이 트리거 기능   
┃ ┃ ┣ 📜 [SummerGameManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/SummerGameManager.cs "") # 여름 미니게임 컨트롤러   
┃ ┃ ┣ 📜 [ThemeManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/ThemeManager.cs "") # 활성화 된 계절에 따른 명화 배치 및 설명 활성화    
┃ ┃ ┣ 📜 [WinterGameManager.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/WinterGameManager.cs "") # 겨울 미니게임 스코어 계산    
┃ ┃ ┗ 📜 [ZoneEntrance.cs](https://github.com/dklee159/vr-project/blob/main/Assets/Scripts/ZoneEntrance.cs "") # 오브젝트 거리에 따라 상호작용 UI on/off 조절   
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

## ⚙ Contributors
**이도경(dklee159)** - Team Leader
- VIVALDI 전체 콘텐츠 기획
- 필요 모델링, SFX, VFX 등 리소스 구매 및 제작
- URP 최적화 셋팅, 전체 맵 라이트맵 베이크
- 중앙홀 계절 선택 액자 아웃라인 기능 추가
- 계절 선택 및 장소 이동 기본 UI 제작
- 장소 이동 및 이동 시 카메라 페이드 아웃 기능 개발
- 미디어 아트관 구현
  - 입장 시 선택한 계절의 영상이 3면에서 재생되는 형식으로 구현
- 명화관 구현
  - 선택한 계절대로 명화 및 설명 변경
  - 포인터로 액자 hover 시 명화에 대한 설명 UI 팝업
- 미니게임 봄 개발
  - 물뿌리개 기울기 각도에 따라 물방울 이벡트 on/off 기능 개발
  - 화분에 이펙트 닿을 시 화분 게이지 상승  
**황원진(hwj0014)**
- 미니게임 공용 타이머 UI 개발
- 미니게임 여름 개발
  - 나비의 움직임 기능 개발
  - 잠자리채와 나비 상호작용 개발
- 미니게임 가을 개발
  - 작물과 호미 상호작용 개발
- 미니게임 겨울 개발
  - 눈덩이와 눈사람 상호작용 및 addForce로 눈덩이 속도 부과

## 🛠️ Dependencies
- Unity **2022.3.17 LTS** or later
