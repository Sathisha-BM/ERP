window.vsmartInternetStatus = {

    check: async function () {

        const isOnline = navigator.onLine;

        if (!isOnline) {
            return {
                isOnline: false,
                downloadMbps: 0,
                uploadMbps: 0,
                latencyMs: 0
            };
        }

        let latencyMs = 0;
        let downloadMbps = 0;

        // =====================================================
        // LATENCY
        // =====================================================

        try {

            const start = performance.now();

            const response = await fetch(
                "/internet-speed-test.bin?ping=" + Date.now(),
                {
                    method: "HEAD",
                    cache: "no-store"
                });

            if (response.ok) {

                latencyMs =
                    Math.round(
                        performance.now() - start
                    );
            }

        }
        catch (error) {

            console.debug(
                "Latency test failed:",
                error
            );

            latencyMs = 0;
        }


        // =====================================================
        // DOWNLOAD SPEED
        // =====================================================

        try {

            const testUrl =
                "/internet-speed-test.bin?download=" +
                Date.now();

            const start =
                performance.now();

            const response =
                await fetch(
                    testUrl,
                    {
                        method: "GET",
                        cache: "no-store"
                    });

            if (!response.ok) {

                console.error(
                    "Speed test HTTP error:",
                    response.status
                );

                return {
                    isOnline: navigator.onLine,
                    downloadMbps: 0,
                    uploadMbps: 0,
                    latencyMs: latencyMs
                };
            }

            let totalBytes = 0;


            // =================================================
            // STREAM
            // =================================================

            if (response.body) {

                const reader =
                    response.body.getReader();

                while (true) {

                    const { done, value } =
                        await reader.read();

                    if (done)
                        break;

                    if (value) {

                        totalBytes +=
                            value.length;
                    }
                }
            }
            else {

                const blob =
                    await response.blob();

                totalBytes =
                    blob.size;
            }


            const end =
                performance.now();

            const seconds =
                (end - start) / 1000;


            if (
                totalBytes > 0 &&
                seconds > 0
            ) {

                downloadMbps =
                    (
                        totalBytes *
                        8 /
                        seconds /
                        1000000
                    );
            }

        }
        catch (error) {

            console.error(
                "Download speed test failed:",
                error
            );

            downloadMbps = 0;
        }


        // =====================================================
        // RESULT
        // =====================================================

        return {

            isOnline:
                navigator.onLine,

            downloadMbps:
                Number(
                    downloadMbps.toFixed(1)
                ),

            uploadMbps: 0,

            latencyMs:
                latencyMs
        };
    }
};