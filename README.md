# <div align="center"><img src="docs/logo.png" alt="icon" width=40> Factory Life</div>
<div align="center">此APP是一款2v2連線的合作類型競技遊戲，玩家要在有限時間內完成衣服工廠作業線上不同類型的事物以獲取分數，簡單的遊玩方式，考驗的是與隊友間的配合與策略。

![C#](https://img.shields.io/badge/C%23-Language-blueviolet)
![Unity](https://img.shields.io/badge/Unity-Platform-black?logo=unity)
![Photon](https://img.shields.io/badge/Photon-Server-blue)
![SQLite](https://img.shields.io/badge/SQLite-Database-9cf?logo=sqlite)


<a href='https://play.google.com/store/apps/details?id=com.roger.joinme'><img alt='Get it on Google Play' src='https://play.google.com/intl/en_us/badges/static/images/badges/en_badge_web_generic.png' width=200 /></a>

</div>

<div align="center">
<a href='#'><img alt='home' src='docs/home.png'/></a>
</div>

***

## List of Contents

1. [Features](#features)
2. [Backend Server](#backendserver)
3. [Database](#database)
4. [Demo](#demo)
5. [Document](#document)
6. [Architecture](#architecture)

<h2 id="features">Features</h2>

我們以google map及google place API為主，以地圖的形式讓使用者對活動所在地更加視覺化，並利用定位功能偵測使用者所在位置，協助其完成報到，避免參與者實際上未到活動地點卻報到的情況。另外，此APP也包含群組聊天室、評價等功能，來輔助活動的進行及後續發展，期望能提供使用者完善的活動機制，讓使用者在舉辦及參與活動上有更方便的管道。

<h2 id="backendserver">Backend Server</h2>

我們使用Photon Server作為我們的backend server，用此建立玩家間的連線，同步玩家的狀態。

<h2 id="database">Databaser</h2>

Database我們使用SQLite來存取使用者的資料，透過SQLite將使用者的角色選擇、玩家名稱等等狀態存放在使用者的local端。

<h2 id="demo">Demo</h2>

