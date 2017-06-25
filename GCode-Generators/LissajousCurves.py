import math
from BiarcInterpolator import BiarcInterpolator

X0 = 140
Y0 = 105
A = 130.0
B = 95.0
a = 3
b = 4
d = math.pi / 2.0

startScript = """
G21         ;All units in mm
M3 S100     ;Pen UP
G0 F6000
"""

endScript = """
M3 S100     ;Pen UP
G4 P0.2     ;Wait for 0.2 seconds
G0 X280Y190 ;Park
"""

penDownScript = """
M3 S0 ;Pen down
G4 P0.2 ;Wait for 0.2 seconds
"""




def gcd(a, b):
    """ Compute the greatest common divisor of a and b """
    while b > 0:
        a, b = b, a % b
    return a


def lcm(a, b):
    """ Compute the lowest common multiple of a and b """
    return a * b / gcd(a, b)


def func_main(t):
    """ Compute value at point t """
    x = A * math.sin(a * t + d)
    y = B * math.sin(b * t)
    return x, y


def func_tan(t):
    """ Compute normalized tangent at point t """
    dx = A * a * math.cos(a * t + d)
    dy = B * b * math.cos(b * t)
    l = math.sqrt(dx * dx + dy * dy)
    return dx / l, dy / l


print(startScript)

step = 0.05

t = 0.0
point = func_main(t)
tan = func_tan(t)

biarc = BiarcInterpolator()

print("G0 X{0:.2f} Y{1:.2f}   ;Go to start position ".format(X0 + point[0], Y0 + point[1]))
print(penDownScript)

while t < 2 * math.pi:
    t1 = t + step
    point1 = func_main(t1)
    tan1 = func_tan(t1)

    # if t >= 1.5:
    #    print(t, point)

    pm, (c1, theta1), (c2, theta2) = biarc.interpolate(point, tan, point1, tan1)

    i = c1[0] - point[0]
    j = c1[1] - point[1]

    if math.fabs(i) < 0.01 or math.fabs(j) < 0.01:
        print("G1 X{0:.3f} Y{1:.3f}".format(X0 + pm[0], Y0 + pm[1]))
    elif theta1 > 0:
        print("G3 X{0:.3f} Y{1:.3f} I{2:.3f} J{3:.3f}".format(X0 + pm[0], Y0 + pm[1], i, j))
    else:
        print("G2 X{0:.3f} Y{1:.3f} I{2:.3f} J{3:.3f}".format(X0 + pm[0], Y0 + pm[1], i, j))

    i = c2[0] - pm[0]
    j = c2[1] - pm[1]
    if math.fabs(i) < 0.01 or math.fabs(j) < 0.01:
        print("G1 X{0:.3f} Y{1:.3f}".format(X0 + pm[0], Y0 + pm[1]))
    elif theta2 > 0:
        print("G2 X{0:.3f} Y{1:.3f} I{2:.3f} J{3:.3f}".format(X0 + point1[0], Y0 + point1[1], i, j))
    else:
        print("G3 X{0:.3f} Y{1:.3f} I{2:.3f} J{3:.3f}".format(X0 + point1[0], Y0 + point1[1], i, j))

    t = t1
    point = point1
    tan = tan1

print(endScript)
