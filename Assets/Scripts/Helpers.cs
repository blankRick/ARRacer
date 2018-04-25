using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers {

	public static Obstacle Rotate90(Obstacle input) {
        Obstacle output = new Obstacle(input);

        output.list[0] = input.list[6];
        output.list[1] = input.list[3];
        output.list[2] = input.list[0];

        output.list[3] = input.list[7];
        //output.list[4] = input.list[4];
        output.list[5] = input.list[1];

        output.list[6] = input.list[8];
        output.list[7] = input.list[5];
        output.list[8] = input.list[2];

        return output;
    }

    public static Obstacle MirrorHorizontal(Obstacle input) {
        Obstacle output = new Obstacle(input);

        output.list[0] = input.list[6];
        output.list[1] = input.list[7];
        output.list[2] = input.list[8];

        output.list[3] = input.list[3];
        //output.list[4] = input.list[4];
        output.list[5] = input.list[5];

        output.list[6] = input.list[0];
        output.list[7] = input.list[1];
        output.list[8] = input.list[2];

        return output;
    }

    public static Obstacle MirrorVertical(Obstacle input) {
        Obstacle output = new Obstacle(input);

        output.list[0] = input.list[2];
        output.list[1] = input.list[1];
        output.list[2] = input.list[0];

        output.list[3] = input.list[5];
        //output.list[4] = input.list[4];
        output.list[5] = input.list[3];

        output.list[6] = input.list[8];
        output.list[7] = input.list[7];
        output.list[8] = input.list[6];

        return output;
    }

    public static Obstacle Negative(Obstacle input) {
        Obstacle output = new Obstacle(input);

        output.list[0] = !input.list[2];
        output.list[1] = !input.list[1];
        output.list[2] = !input.list[0];

        output.list[3] = !input.list[5];
        output.list[4] = !input.list[4];
        output.list[5] = !input.list[3];

        output.list[6] = !input.list[8];
        output.list[7] = !input.list[7];
        output.list[8] = !input.list[6];

        return output;
    }

    public static int GetRating(Obstacle input) {
        int rating = (input.list[0] ? 1 : 0) + (input.list[1] ? 1 : 0) + (input.list[2] ? 1 : 0) +
                     (input.list[3] ? 1 : 0) + (input.list[4] ? 1 : 0) + (input.list[5] ? 1 : 0) +
                     (input.list[6] ? 1 : 0) + (input.list[7] ? 1 : 0) + (input.list[8] ? 1 : 0);
        return rating;
    }

}
