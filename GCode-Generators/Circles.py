import math

X0 = 140
Y0 = 100
radius = 45
n = 24

startScript = """
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F5000
"""

endScript = """
M3 S100     ;Pen UP
"""

print(startScript)

print("G0 X{} Y{}   ;Go to start position ".format(X0, Y0))
print("M3 S0 ;Pen down")

for i in range(n):
    x = radius * math.cos(i * 2.0 * math.pi / n)
    y = radius * math.sin(i * 2.0 * math.pi / n)
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0 + 2*x, Y0 + 2*y, x, y))
    print("G3 X{0:.2f} Y{1:.2f} I{2:.2f} J{3:.2f}".format(X0, Y0, -x, -y))

print(endScript)



