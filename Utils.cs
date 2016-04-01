using System;
using System.Collections.Generic;
using System.Text;
using OpenSURFcs;

class Utils
{
    private const float FLT_MAX = 3.402823466e+38F;        /* max value */

    public static List<IPoint>[] getMatches(List<IPoint> ipts1, List<IPoint> ipts2)
    {
        double dist;
        double d1, d2;
        IPoint match = new IPoint();

        List<IPoint>[] matches = new List<IPoint>[2];
        matches[0] = new List<IPoint>();
        matches[1] = new List<IPoint>();

        for (int i = 0; i < ipts1.Count; i++)
        {
            d1 = d2 = FLT_MAX;

            for (int j = 0; j < ipts2.Count; j++)
            {
                dist = GetDistance(ipts1[i], ipts2[j]);

                if (dist < d1) // if this feature matches better than current best
                {
                    d2 = d1;
                    d1 = dist;
                    match = ipts2[j];
                }
                else if (dist < d2) // this feature matches better than second best
                {
                    d2 = dist;
                }
            }

            // If match has a d1:d2 ratio < 0.65 ipoints are a match
            if (d1 / d2 < 0.77) //越小Match点越少
            {
                matches[0].Add(ipts1[i]);
                matches[1].Add(match);
            }
        }
        return matches;
    }

    private static  double GetDistance(IPoint ip1, IPoint ip2)
    {
        float sum = 0.0f;
        for (int i = 0; i < 64; ++i)
            sum += (ip1.descriptor[i] - ip2.descriptor[i]) * (ip1.descriptor[i] - ip2.descriptor[i]);
        return Math.Sqrt(sum);
    }
}

