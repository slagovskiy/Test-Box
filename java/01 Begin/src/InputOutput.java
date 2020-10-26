import java.util.Scanner;

public class InputOutput {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        String login, password;
        System.out.print("Enter your login: ");
        login = s.next();
        System.out.print("Enter your password: ");
        password = s.next();
        System.out.println("Login: " + login + "\nPassword: " + password);
    }
}
