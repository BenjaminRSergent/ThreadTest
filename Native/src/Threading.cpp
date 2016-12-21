#include <thread>
#include <chrono>
class ThreadTest;

extern "C" {
	typedef void (*CALLBACK)(int);
	static std::shared_ptr<ThreadTest> test;
	void StartThread(CALLBACK cb) {
		test = std::make_shared<ThreadTest>(cb);
	}
	void StopThread() {
		test.reset();
	}
}

class ThreadTest {
public:
	ThreadTest(CALLBACK cb) {
		mainLoop = std::make_shared<std::thread>(
		[this, cb]() {
			using namespace std::chrono_literals;
			while(!done) {
				cb(cnt++);
				std::this_thread::sleep_for(1s);
			}
		}
		);
	}

	~ThreadTest() {
		done = true;
		mainLoop->join();
	}
private:
	int cnt = 0;
	bool done = false;
	std::shared_ptr<std::thread> mainLoop;
};
