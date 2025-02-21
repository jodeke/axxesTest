plugins {
   application
    idea
}

repositories {
    mavenCentral()
}

java {
    toolchain {
        languageVersion = JavaLanguageVersion.of(21)
    }
}

dependencies {
    testImplementation(platform("org.junit:junit-bom:5.10.1"))
    testImplementation("org.junit.jupiter:junit-jupiter")
    testRuntimeOnly("org.junit.platform:junit-platform-launcher")
    testImplementation("com.approvaltests:approvaltests:24.17.0")
}

group = "com.gildedtros"

tasks.named<Test>("test") {
    useJUnitPlatform()
}