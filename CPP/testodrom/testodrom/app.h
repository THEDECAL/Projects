#pragma once
#include <vector>
#include <memory>
#include <algorithm>
#include <string>
#include "fileMngr.cpp"
#include "tools.cpp"
#include "profile.h"
using fileMngr::fmngr;

namespace app{
	class application{
		static application* pApplication;
		profile::user* pAccount;
		application();
	public:
		static application* getRef();
		void run();
		~application();
	};
}
