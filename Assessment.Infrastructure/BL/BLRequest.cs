﻿using Assessment.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.BL
{
    public class BLRequest
    {
        private IMakeRequest _makeRequest;

        public BLRequest(IMakeRequest makeRequest)
        {
            _makeRequest = makeRequest;
        }

        public Task<string> MakeARequest(string input, int service)
        {
            return _makeRequest.MakeRequests(input, service);
        }
    }
}
