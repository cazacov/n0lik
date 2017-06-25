import numpy as np
import math


class BiarcInterpolator:
    MIN_DENOMINATOR = 0.001

    def __init__(self):
        zz = 15

    def interpolate(self, point1, tangent1, point2, tangent2):
        v = np.subtract(point2, point1)
        t = np.add(tangent1, tangent2)

        num = -np.dot(v, t) + math.sqrt(np.square(np.dot(v, t)) + 2 * (1 - np.dot(tangent1, tangent2)) * np.dot(v, v))
        den = 2 * (1 - np.dot(tangent1, tangent2))

        if den > self.MIN_DENOMINATOR:
            d2 = num / den
        else:
            den2 = 4 * np.dot(v, tangent2)
            if math.fabs(den2) > self.MIN_DENOMINATOR:
                d2 = np.dot(v, v) / den2
            else:
                pm = point1 + np.multiply(v, 0.5)
                c1 = point1 + np.multiply(v, 0.25)
                c2 = point1 + np.multiply(v, 0.75)
                r1 = np.divide(np.linalg.norm(v), 4)
                r2 = r1
                if v[0] * tangent2[1] - v[1] * tangent2[0] < 0:
                    theta1 = math.pi
                    theta2 = -math.pi
                else:
                    theta2 = -math.pi
                    theta1 = math.pi
                return pm, (c1, theta1), (c2, theta2)

        d1 = d2
        #pm = np.add(point1, np.multiply(d1, tangent1))
        #pm = np.add(pm, np.multiply(np.dot(v, tangent2) - np.dot(np.multiply(d1, tangent1), tangent2), tangent2))
        pm = np.divide(np.add(point1, np.add(point2, np.multiply(d2, np.subtract(tangent1, tangent2)))), 2)

        n1 = -tangent1[1], tangent1[0]
        s1 = np.dot(np.subtract(pm, point1), np.subtract(pm, point1)) / np.dot(np.multiply(2, n1),
                                                                               np.subtract(pm, point1))
        c1 = np.add(point1, np.multiply(s1, n1))

        n2 = -tangent2[1], tangent2[0]
        s2 = np.dot(np.subtract(pm, point2), np.subtract(pm, point2)) / np.dot(np.multiply(2, n2),
                                                                               np.subtract(pm, point2))
        c2 = np.add(point2, np.multiply(s2, n2))

        r1 = math.fabs(s1)
        r2 = math.fabs(s2)

        op1 = np.divide(np.subtract(point1, c1), r1)
        om1 = np.divide(np.subtract(pm, c1), r1)
        op2 = np.divide(np.subtract(point2, c2), r2)
        om2 = np.divide(np.subtract(pm, c2), r2)

        cross1 = op1[0] * om1[1] - op1[1] * om1[0]
        cross2 = op2[0] * om2[1] - op2[1] * om2[0]

        dd = np.dot(op1, om1)
        if dd >= 1.0:
            theta1 = 0
        elif dd <= -1.0:
            theta1 = math.pi
        else:
            theta1 = math.acos(dd)

        if d1 > 0:
            if cross1 <= 0:
                theta1 = -theta1
        else:
            if cross1 > 0:
                theta1 = -2.0 * math.pi + theta1
            else:
                theta1 = 2.0 * math.pi - theta1

        dd = np.dot(op2, om2)
        if dd >= 1.0:
            theta2 = 0
        elif dd <= -1.0:
            theta2 = math.pi
        else:
            theta2 = math.acos(dd)
        if d2 > 0:
            if cross2 <= 0:
                theta2 = -theta2
        else:
            if cross2 > 0:
                theta2 = -2.0 * math.pi + theta2
            else:
                theta2 = 2.0 * math.pi - theta2

        return pm, (c1, theta1), (c2, theta2)
