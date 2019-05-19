using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class DynamicMojo
    {
        /// <summary>
        /// Swaps the function pointers for a and b, effectively swapping the method bodies.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// a and b must have same signature
        /// </exception>
        /// <param name="a">Method to swap</param>
        /// <param name="b">Method to swap</param>
        /// https://stackoverflow.com/questions/7299097/dynamically-replace-the-contents-of-a-c-sharp-method
        /// by C. McCoy IV
        public static void SwapMethodBodies(MethodInfo a, MethodInfo b)
        {
            if (!HasSameSignature(a, b))
            {
                throw new ArgumentException("a and b must have have same signature");
            }

            RuntimeHelpers.PrepareMethod(a.MethodHandle);
            RuntimeHelpers.PrepareMethod(b.MethodHandle);

            unsafe
            {
                if (IntPtr.Size == 4)
                {
                    int* inj = (int*)b.MethodHandle.Value.ToPointer() + 2;
                    int* tar = (int*)a.MethodHandle.Value.ToPointer() + 2;

                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    int tmp = *tarSrc;
                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
                    *injSrc = (((int)tarInst + 5) + tmp) - ((int)injInst + 5);
                }
                else
                {
                    throw new NotImplementedException($"{nameof(SwapMethodBodies)} doesn't yet handle IntPtr size of {IntPtr.Size}");
                }
            }
        }

        private static bool HasSameSignature(MethodInfo a, MethodInfo b)
        {
            bool sameParams = !a.GetParameters().Any(x => !b.GetParameters().Any(y => x == y));
            bool sameReturnType = a.ReturnType == b.ReturnType;
            return sameParams && sameReturnType;
        }
    }
}
