#include <thread>
class ThreadTest {
public:
	ThreadTest() {
		mainLoop = std::make_shared<std::thread>(
		[]() {
			while(!done) {
				
			}
		}
		);
	}
	
	~ThreadTest() {
		done = true;
		mainLoop.join();
	}
private:
	bool done = false;
	std::shared_ptr<std::thread> mainLoop;
}
extern "C" {	
	static std::shared_ptr<ThreadTest> test;
	void StartThread() {)
		test = make_shared<ThreadTest>();
	}
}