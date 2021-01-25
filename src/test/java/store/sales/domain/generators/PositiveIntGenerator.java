package store.sales.domain.generators;

import com.pholser.junit.quickcheck.generator.GenerationStatus;
import com.pholser.junit.quickcheck.generator.Generator;
import com.pholser.junit.quickcheck.random.SourceOfRandomness;

import static java.lang.Integer.MAX_VALUE;
import static java.lang.Math.abs;
import static java.util.Arrays.asList;

public class PositiveIntGenerator extends Generator<Integer> {
    private int maxInt = MAX_VALUE;
    private int minInt = 0;

    public PositiveIntGenerator() {
        super(asList(Integer.class, int.class));
    }

    @Override
    public Integer generate(SourceOfRandomness random, GenerationStatus status) {
        return random.nextInt(minInt, maxInt);
    }

    public void configure(int minInt, int maxInt) {
        this.minInt = abs(minInt);
        this.maxInt = maxInt;
    }
}
