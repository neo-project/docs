
"""
This example shows how to to work with input parameters.
Test & Build:
neo> build 5-calculator.py test 070202 02 False False
"""


def Main(operation, a, b):

    if operation == 'add':
        return a + b

    elif operation == 'sub':
        return a - b

    elif operation == 'mul':
        return a * b

    elif operation == 'div':
        return a / b

    else:
        return -1
