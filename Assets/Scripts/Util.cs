using System.Collections;

public static class Util {

	public static int countDigits(int number) {
		int digits = 0;
		while (number > 0) {
			number /= 10;
			digits++;
		}
		return digits;
	}
}
