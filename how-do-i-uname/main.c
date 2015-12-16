#include <stdio.h>
#include <sys/param.h>
#include <sys/sysctl.h>
#include <string.h>
#include <stdlib.h>
#include <sys/utsname.h>
#include <errno.h>

#define BUFFER_LEN 2

int main() {
    // Definitions:
    int mib[2];
    size_t len = BUFFER_LEN;
    char kernelVersion[BUFFER_LEN];

    // Get the kernel's version as a string called "kernelVersion":
    mib[0] = CTL_KERN;
    mib[1] = KERN_OSRELEASE;

    printf("len before: %lu\n", len);
    printf("errno before: %d\n", errno);
    printf("** sysctl call **\n");
    int ret = sysctl(mib, 2, kernelVersion, &len, NULL, 0);
    printf("sysctl ret: %d\n", ret);
    printf("terminator: %d\n", kernelVersion[len]);
    printf("errno after: %d\n", errno);
    printf("len after: %lu\n", len);
    printf("OS Version: %s\n", kernelVersion);
    printf("CTL_KERN: %d\n", CTL_KERN);
    printf("KERN_OSRELEASE: %d\n", KERN_OSRELEASE);
    printf("ENOMEM: %d\n", ENOMEM);
    printf("sizeof(struct utsname): %lu\n", sizeof(struct utsname));
}
