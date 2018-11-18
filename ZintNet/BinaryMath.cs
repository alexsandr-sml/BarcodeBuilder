using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZintNet
{
    public static class BinaryMath
    {
        internal static short[] BCD = {
	        0, 0, 0, 0,
	        1, 0, 0, 0,
	        0, 1, 0, 0,
	        1, 1, 0, 0,
	        0, 0, 1, 0,
	        1, 0, 1, 0,
	        0, 1, 1, 0,
	        1, 1, 1, 0,
	        0, 0, 0, 1,
	        1, 0, 0, 1 };

        public static void BinaryAdd(short[] accumulator, short[] buffer)
        {
            // Binary addition.
            int carry = 0;
            bool done;

            for (int i = 0; i < 112; i++)
            {
                done = false;
                if (((buffer[i] == 0) && (accumulator[i] == 0)) && ((carry == 0) && (done == false)))
                {
                    accumulator[i] = 0;
                    carry = 0;
                    done = true;
                }

                if (((buffer[i] == 0) && (accumulator[i] == 0)) && ((carry == 1) && (done == false)))
                {
                    accumulator[i] = 1;
                    carry = 0;
                    done = true;
                }

                if (((buffer[i] == 0) && (accumulator[i] == 1)) && ((carry == 0) && (done == false)))
                {
                    accumulator[i] = 1;
                    carry = 0;
                    done = true;
                }

                if (((buffer[i] == 0) && (accumulator[i] == 1)) && ((carry == 1) && (done == false)))
                {
                    accumulator[i] = 0;
                    carry = 1;
                    done = true;
                }

                if (((buffer[i] == 1) && (accumulator[i] == 0)) && ((carry == 0) && (done == false)))
                {
                    accumulator[i] = 1;
                    carry = 0;
                    done = true;
                }

                if (((buffer[i] == 1) && (accumulator[i] == 0)) && ((carry == 1) && (done == false)))
                {
                    accumulator[i] = 0;
                    carry = 1;
                    done = true;
                }
                if (((buffer[i] == 1) && (accumulator[i] == 1)) && ((carry == 0) && (done == false)))
                {
                    accumulator[i] = 0;
                    carry = 1;
                    done = true;
                }
                if (((buffer[i] == 1) && (accumulator[i] == 1)) && ((carry == 1) && (done == false)))
                {
                    accumulator[i] = 1;
                    carry = 1;
                    done = true;
                }
            }
        }

        public static void BinarySubtract(short[] accumulator, short[] buffer)
        {
            // 2's compliment subtraction.
            // Subtract buffer from accumulator and put answer in accumulator.
            int i;
            short[] subBuffer = new short[112];

            for (i = 0; i < 112; i++)
            {
                if (buffer[i] == 0)
                    subBuffer[i] = 1;

                else
                    subBuffer[i] = 0;
            }

            BinaryAdd(accumulator, subBuffer);
            subBuffer[0] = 1;

            for (i = 1; i < 112; i++)
                subBuffer[i] = 0;

            BinaryAdd(accumulator, subBuffer);
        }

        public static void ShiftDown(short[] buffer)
        {
            buffer[102] = 0;
            buffer[103] = 0;

            for (int i = 0; i < 102; i++)
                buffer[i] = buffer[i + 1];
        }

        public static void ShiftUp(short[] buffer)
        {
            for (int i = 102; i > 0; i--)
                buffer[i] = buffer[i - 1];

            buffer[0] = 0;
        }

        public static short IsLarger(short[] accumulator, short[] register)
        {
            // Returns 1 if accumulator is larger than register, else 0.
            bool latch = false;
            int index = 103;
            short larger = 0;

            do
            {
                if ((accumulator[index] == 1) && (register[index] == 0))
                {
                    latch = true;
                    larger = 1;
                }

                if ((accumulator[index] == 0) && (register[index] == 1))
                    latch = true;

                index--;
            } while ((latch == false) && (index >= -1));

            return larger;
        }

        public static void BinaryLoad(short[] register, string data)
        {
            int length = data.Length;
            short[] tempBuffer = new short[112];

            Array.Clear(register, 0, 112);
            for (int index = 0; index < length; index++)
            {
                Array.Copy(register, tempBuffer, 112);

                for (int i = 0; i < 9; i++)
                    BinaryAdd(register, tempBuffer);

                for (int i = 0; i < 112; i++)
                {
                    if (i < 4)
                        tempBuffer[i] = BCD[((data[index] - '0') * 4) + i];

                    else
                        tempBuffer[i] = 0;
                }

                BinaryAdd(register, tempBuffer);
            }
        }
    }
}
