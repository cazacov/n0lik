import math

X0 = 140
Y0 = 100
radius = 95
n = 41
step = 17

startScript = """
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F6000
"""

endScript = """
M3 S100     ;Pen UP
"""

print(startScript)

print("G0 X{} Y{}   ;Go to start position ".format(X0 + radius, Y0))
print("M3 S0 ;Pen down".format(X0 + radius, Y0))

nextPoint = 0
for i in range(n):
    nextPoint = nextPoint + step
    angle = nextPoint * 2.0 * math.pi / n
    x = radius * math.cos(angle)
    y = radius * math.sin(angle)
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 + x, Y0 + y))

print(endScript)



