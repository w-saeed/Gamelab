import cv2
from cvzone.HandTrackingModule import HandDetector
import socket
import math

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
    hands, img = detector.findHands(img)

    data = []
    if hands:
        hand1 = hands[0]
        lmList = hand1['lmList']
        bbox1 = hand1["bbox"]
        centerPoint1 = hand1["center"]
        handtype1 = hand1["type"]

        fingers1 = detector.fingersUp(hand1)

    if len(hands) == 2:
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

        if fingers2 == [1, 1, 1, 1, 1] or fingers2 == [1, 1, 1, 1, 1]:
            print("stop")
        else:
            print("go")

        data = [centerPoint1, centerPoint2]
        print(data)


        #data3 =map(int, data)
        p1x = centerPoint1[0]
        p1y = centerPoint1[1]

        p2x = centerPoint2[0]
        p2y = centerPoint2[1]

        degree = ((p2y - p1y) / (p2x - p1x))
        print(degree)

        A = (180 / math.pi) * math.atan(degree)
        print(A)
        #degree = (180 / math.PI) * math.Atan(((p2y - p1y) / (p2x - p1x)))
        #print(degree)

        length, info, img = detector.findDistance(centerPoint1, centerPoint2, img)  # with draw
        sock.sendto(str.encode(str(A)), serverAddressPort)

    cv2.imshow("Image", img)
    cv2.waitKey(1)