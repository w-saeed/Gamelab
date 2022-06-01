import cv2

from cvzone.HandTrackingModule import HandDetector

import socket
import math
import os

width, height = 1500, 720
cap = cv2.VideoCapture(0)

cap.set(3, width)
cap.set(4, height)
detector = HandDetector(maxHands=2, detectionCon=0.8)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

serverAddressPort = ("127.0.0.1", 5052)


while True:

    # Get image frame

    success, img = cap.read()
    if not success:
          print("Ignoring empty camera frame.")
          # If loading a video, use 'break' instead of 'continue'.
          continue
    hands, img = detector.findHands(img)

    #if len(hands) != 2:
    #    continue #Ignoring when Hands not found

    data = []





    if len(hands) == 2:

        hand1 = hands[0]

        lmList = hand1['lmList']

        bbox1 = hand1["bbox"]

        centerPoint1 = hand1["center"]

        handtype1 = hand1["type"]

        fingers1 = detector.fingersUp(hand1)
    
        hand2 = hands[1]

        lmList2 = hand2['lmList']

        bbox2 = hand2["bbox"]

        centerPoint2 = hand2["center"]

        handtype2 = hand2["type"]


        fingers2 = detector.fingersUp(hand2)


        #print(handtype1, handtype2)

        #print(centerPoint1,centerPoint2)

        #data = [centerPoint1]

        #data2 =[centerPoint2]




        data = [centerPoint1, centerPoint2]
        print(data)



        #data3 =map(int, data)

        p1x = centerPoint1[0]

        p1y = centerPoint1[1]


        p2x = centerPoint2[0]

        p2y = centerPoint2[1]

        if (p2x - p1x) != 0:
            degree = ((p2y - p1y) / (p2x - p1x))

        #print(degree)
        angle = (180 / math.pi) * math.atan(degree)
        

        os.system("cls")
        is_hand_open=0 #if true 0 else 1
        if fingers1 == [1, 1, 1, 1, 1] and fingers2 == [1, 1, 1, 1, 1]:
            print("stop")
            is_hand_open=0
        else:
            is_hand_open=1
            print("go")

        #degree = (180 / math.PI) * math.Atan(((p2y - p1y) / (p2x - p1x)))
        #print(degree)
        length, info, img = detector.findDistance(centerPoint1, centerPoint2, img)  # with draw

        print("distance: ", length)
        print(angle)
        separator = ";"
        data_tosend = str.encode(str(angle) + separator + str(length) + separator + str(is_hand_open))
        print(data_tosend)
        sock.sendto(data_tosend, serverAddressPort)

    cv2.imshow("Image", img)

    cv2.waitKey(1)