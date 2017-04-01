import math

X0 = 140
Y0 = 100
size = 95
n = 20

startScript = """
; Hyperbola curve
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F5000
"""

endScript = """
M3 S100     ;Pen UP
"""

print(startScript)

print("G0 X{} Y{}   ;Go to start position ".format(X0 + size, Y0))
print("M3 S0 ;Pen down".format(X0 + size, Y0))

for i in range(n + 1):
    r1 = size * i / n
    r2 = size * (n-i) / n
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 + r1, Y0))

    print("G1 X{0:.2f} Y{1:.2f}".format(X0, Y0 + r2))
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 - r1, Y0))
    print("G1 X{0:.2f} Y{1:.2f}".format(X0, Y0 - r2))
    print("G1 X{0:.2f} Y{1:.2f}".format(X0 + r1, Y0))

print(endScript)



