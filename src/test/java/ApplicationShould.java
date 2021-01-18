import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class ApplicationShould {
    @Test
    void works() {
        Application application = new Application();
        Assertions.assertTrue(application.isWorking());
    }
}
