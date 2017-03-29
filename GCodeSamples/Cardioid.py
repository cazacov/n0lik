import math

X0 = 140
Y0 = 100
radius = 95
n = 100

startScript = """
; Cardioid curve
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F4000
"""

endScript = """
M3 S100     ;Pen UP
"""

print(startScript)

print("G0 X{} Y{}   ;Go to start position ".format(X0 + radius, Y0))
print("M3 S0 ;Pen down".format(X0 + radius, Y0))

for i in range(0, n, 2):
    x = radius * math.cos(i * 4 * math.pi / n + math.pi)
    y = radius * math.sin(i * 4 * math.pi / n + math.pi)
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 + x, Y0 + y))

    x2 = radius * math.cos((i + 1) * 4 * math.pi / n + math.pi)
    y2 = radius * math.sin((i + 1) * 4 * math.pi / n + math.pi)
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0 + x2, Y0 + y2, -x, -y))

    x3 = radius * math.cos((i + 1) * 2 * math.pi / n)
    y3 = radius * math.sin((i + 1) * 2 * math.pi / n)
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 + x3, Y0 + y3))

    x4 = radius * math.cos((i + 2) * 2 * math.pi / n)
    y4 = radius * math.sin((i + 2) * 2 * math.pi / n)
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0 + x4, Y0 + y4, -x3, -y3))

print(endScript)



