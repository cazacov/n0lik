import math

X0 = 140
Y0 = 100
radius = 35
n = 20

startScript = """
; Cardioid curve as envelope of a pencil of circles
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F5000
"""

endScript = """
M3 S100     ;Pen UP
"""

print(startScript)

print("G0 X{} Y{}   ;Go to start position ".format(X0 + radius, Y0))
print("M3 S0 ;Pen down".format(X0 + radius, Y0))

for i in range(n):
    angle = i * 2 * math.pi / n
    x = radius * math.cos(angle)
    y = radius * math.sin(angle)
    r = radius * math.sqrt(2 - 2 * math.cos(angle))
    x1 = 2*x - radius
    y1 = 2*y
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0 + x1, Y0 + y1, x - radius, y))
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0 + radius, Y0, radius - x, -y))

print(endScript)



