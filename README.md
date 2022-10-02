![](RackMultipart20221002-1-3g1sa9_html_936cddd3b12cbd09.jpg)

# Umsetzung einer Anwendung zum Steuern eines Fahrzeuges mittels Handbewegung in einer simulierten Umgebung in Unity

vorgelegt von:

Mulham Alesali

und

Waleed Saeed

##


## **Zielsetzung**

Ziel dieser Arbeit ist, ein Autofahren-Spiel zu entwickeln. In diesem Spiel soll es möglich sein, das Fahrzeug mittels Handbewegungen zu steuern. Die Erkennung der Handbewegung soll mithilfe der Kamera erfolgen. Es soll keine externe Hardware dafür benötigt werden.

## **Beschreibung des Service (Problem)**

In den üblichen Autofahrspielen werden die Fahrzeuge mit der Tastatur gesteuert. Eine andere Möglichkeit wäre die Verwendung anderer externer Eingabegeräte, wie z. B. RacingWheel-Geräte. Es besteht jedoch das Problem, dass diese Geräte nicht immer vorhanden sind.

In dieser Arbeit wird die Umsetzung eines neuen Ansatzes vorgestellt.

Bei diesem Ansatz wird eine Kamera als Eingabegerät verwendet und anhand der Computer-Vision-Technologie werden die Hände des Spielers erkannt. Durch die Bewegung der Hände kann der Spieler dann das Fahrzeug steuern. Dieser Ansatz soll die Steuerung des Fahrzeugs erleichtern und der Benutzer soll das Gefühl bekommen, dass er ein Steuerrad in den Händen hat.

## **Technologien (Lösungsansatz)**

Die Entwicklung der Anwendung wird im Unity-Programm und Visual Studio erfolgen. Für die Entwicklung des Projektes wurde Unity (V. 2021.3.3f1) benutzt. Der Code wird mit der Programmiersprachen C# und Python (V. 3.10.5) verfasst. Für das Steuern des Autos wird das Framework Mediapipe ("Hands", 2022) verwendet. Die Implementierung des, der Lösungen von Computer Vision Problemen bietet. Die Erkennung der Hände geschieht in einem Pythonscript. Um die Daten aus dem Python-Skript an Unity zu übermitteln, wird das Python-Socket-Modul verwendet. Die Anwendung soll nur mit Windows-Betriebssystemen kompatibel sein.

## **Steuern des Autos (Lösungsansatz)**

Um das Fahrzeug zu steuern, muss man die Hände vor die Kamera halten, damit die Kamera die Hände des Benutzers erkennt.

Zur Steuerung des Fahrzeugs soll man zwischen drei Haupthandpositionen entscheiden.

1. Die erste Position ist es, wenn der Abstand zwischen den beiden Händen zu gering ist. Diese Position wird zum Bremsen des Fahrzeugs verwendet (vgl. Abbildung 4).
2. In der zweiten Position sollen beide Hände auf sein und es soll genug Abstand zwischen den Händen geben. In dieser Position soll das Fahrzeug vorwärtsfahren (vgl. Abbildung 1). Die Kraft des Fahrzeugmotors hängt von der Entfernung zwischen den beiden Händen ab.
3. Wenn die beiden Hände geschlossen sind und ein ausreichender Abstand zwischen den Händen besteht, sollte das Fahrzeug rückwärtsfahren (vgl. Abbildung 5).

Um die Lenkung des Fahrzeugs zu steuern, sollten die Hände in die richtige Richtung bewegt werden. (vgl. Abbildung 2)

![](RackMultipart20221002-1-3g1sa9_html_4bb6ec346b4ecd46.png)

Abbildung 1: Die Handpositionen für das Geradeausfahren

![](RackMultipart20221002-1-3g1sa9_html_2297c0ac1f90b407.png) ![](RackMultipart20221002-1-3g1sa9_html_53b186cfa46e9312.png)

Abbildung 2: Steuerung der Lenkung

![](RackMultipart20221002-1-3g1sa9_html_5c5a3ecd61137820.png)

Abbildung 4: Handstellung zum Bremsen

## ![](RackMultipart20221002-1-3g1sa9_html_e7fbe504720ac23f.png)

## Abbildung 5: Handstellung zum Rückwertfahren

## **Ergebnis**

Der Spieler kann das Auto problemlos ohne externe Hardware außer der Kamera und dem Computer fahren.

## Abbildung 6: Menüfenster ![](RackMultipart20221002-1-3g1sa9_html_2b1e3c50ca0490fb.png)

![](RackMultipart20221002-1-3g1sa9_html_d54185984cd586c8.png)Abbildung 7: Die implementierte Umgebung.

## **Fazit**

Im Rahmen dieses Projekt wurde ein funktionsfähiges Kontroller in Unity umgesetzt. In n diesem Spiel ist es möglich, das Fahrzeug mittels Handbewegungen zu steuern. Die Erkennung der Handbewegung erfolgt mithilfe der Kamera. Es wird keine externe Hardware dafür benötigt.

##


## **Quellen**

_Hands_. mediapipe. (2022). Retrieved 4 July 2022, from https://google.github.io/mediapipe/solutions/hands.html.
