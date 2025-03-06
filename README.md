# Unity Project: VIVALDI Exhibition
Welcome to **VIVALDI Exhibition**! 이 유니티 프로젝트는 메타버즈 개발팀 사이드 VR 프로젝트 입니다.

## 📁 Project Structure
📂 VIVALDI Exhibition   
┣ 📂 Assets  
┃ ┣ 📂 Scripts   
┃ ┃ ┣ 📜 AudioManager.cs # 장소에 따라 오디오 조절    
┃ ┃ ┣ 📜 FadeScreen.cs # 공간 이동 시 카메라에 페이드 아웃 효과   
┃ ┃ ┣ 📜 GameManager.cs # 씬 교체 시 오브젝트 파괴 여부 조절   
┃ ┃ ┣ 📜 HoverFrame.cs # 액자 아웃라인 효과 on/off   
┃ ┃ ┣ 📜 MiniGame.cs # 계절 별 미니 게임 진행 조절   
┃ ┃ ┣ 📜 PlaceTransitionManager.cs # 씬 이동 시 플레이어 위치 및 카메라 설정   
┃ ┃ ┣ 📜 SceneTransitionManager.cs # 활성화 된 계절 씬 로드   
┃ ┃ ┣ 📜 ThemeManager.cs # 활성화 된 계절에 따른 명화 배치 및 설명 활성화    
┃ ┃ ┗ 📜 ZoneEntrance.cs # 오브젝트 거리에 따라 상호작용 UI on/off 조절   
┃ ┗ 📂 Scenes   
┃ ┃ ┣ 🎬 SampleScene.unity   # 메인씬
┃ ┃ ┗ 📂 VivaldiScenes   # 계절 별 미니게임 씬

### 🛠️ Dependencies
- Unity **2022.3.17 LTS** or later
