public class BasicTypes {
    public static void main(String[] args) {

        byte n1 = 127;
        short n2 = 32000;
        int n3 = 2_000_000_000;
        long n4 = 5_000_000_000_000_000L;

        float n5 = 123.324324F;
        double n6 = 432423.2352342346D;

        boolean b1 = true;
        boolean b2 = false;

        char c1 = 'a';
        char c2 = 'B';

        String s1 = "qwertyuiASDDF";

        final float PI = 3.1415F;

        System.out.println(n1);
        System.out.println(n2);
        System.out.println(n3);
        System.out.println(n4);
        System.out.println(n5);
        System.out.println(n6);

        System.out.println(b1);
        System.out.println(b2);

        System.out.println(c1);
        System.out.println(c2);

        System.out.println(s1);

        System.out.println(PI);

        System.out.println("======================================");

        System.out.println("Byte: " + Byte.MAX_VALUE + " " + Byte.MIN_VALUE);
        System.out.println("Short: " + Short.MAX_VALUE + " " + Short.MIN_VALUE);
        System.out.println("Int: " + Integer.MAX_VALUE + " " + Integer.MIN_VALUE);
    }
}
